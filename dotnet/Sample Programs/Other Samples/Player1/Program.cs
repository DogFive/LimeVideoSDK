﻿// Copyright 2012-2016 Cameron Elliott  http://cameronelliott.com
// BSD License terms
// See file LICENSE.txt in the top-level directory

using LimeVideoSDK.QuickSyncTypes;
using LimeVideoSDK.QuickSync;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

//inspired by MediaEngineApp
namespace Player1
{


    class FPSCounter
    {
        const int frames = 100;
        long lpFreq;
        [DllImport("Kernel32.dll")]
        static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        static extern bool QueryPerformanceFrequency(out long lpFrequency);

        List<long> timestamps = new List<long>(frames);
        int nframe = 0;

        public FPSCounter()
        {
            QueryPerformanceFrequency(out lpFreq);
        }


        public void PrintFPS()
        {
            long count;
            QueryPerformanceCounter(out count);

            timestamps.Insert(0, count);
            if (timestamps.Count() > frames)
            {
                var diff = timestamps[0] - timestamps[frames];
                timestamps.RemoveAt(frames);
                if (nframe++ % 400 == 0)
                    Console.WriteLine("{0:f1} fps", frames / ((double)diff / lpFreq));
            }
        }
    }


    class Program
    {

        // XXX IMPORTANT FLAGS
        static bool useSystemMemoryNotVideoMemory = false;




        private static SharpDX.Direct3D11.Device device;
        private static SwapChain swapChain;




        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The args.</param>
        [STAThread]
        unsafe static void Main(string[] args)
        {
            ConfirmQuickSyncReadiness.HaltIfNotReady();

            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                throw new Exception("DirectX sample only works on Windows");


            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // keep ascending directories until 'media' folder is found
            for (int i = 0; i < 10 && !Directory.Exists("Media"); i++)
                Directory.SetCurrentDirectory("..");
            Directory.SetCurrentDirectory("Media");

            string fn;
            fn = @"BigBuckBunny_320x180.264";
            //fn = @"C:\w\BigBuckBunny_1920x1080.264";
            //fn = @"C:\w\bbb_sunflower_2160p_30fps_normal_track1.h264";


            var s = File.Open(fn, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);


            var buf = new byte[1000];
            int n = s.Read(buf, 0, buf.Length);
            s.Position = 0;
            Trace.Assert(n == buf.Length);

            var decVideoParam = QuickSyncStatic.DecodeHeader(buf, CodecId.MFX_CODEC_AVC);

            mfxVideoParam vppVideoParam = new mfxVideoParam();// = SetupVPPConfiguration(decVideoParam.mfx.FrameInfo.CropW, decVideoParam.mfx.FrameInfo.CropH);
            vppVideoParam.vpp.In = decVideoParam.mfx.FrameInfo;
            vppVideoParam.vpp.Out = decVideoParam.mfx.FrameInfo;

            decVideoParam.IOPattern = IOPattern.MFX_IOPATTERN_OUT_SYSTEM_MEMORY;
            vppVideoParam.IOPattern = IOPattern.MFX_IOPATTERN_IN_SYSTEM_MEMORY;

            vppVideoParam.IOPattern |= useSystemMemoryNotVideoMemory ?
            IOPattern.MFX_IOPATTERN_OUT_SYSTEM_MEMORY : IOPattern.MFX_IOPATTERN_OUT_VIDEO_MEMORY;

            int vppOutWidth;
            int vppOutHeight;

            Console.WriteLine($"Bitstream -- width {0} height {1}",
                 decVideoParam.mfx.FrameInfo.CropW,
                 decVideoParam.mfx.FrameInfo.CropH);

            // vppOutWidth = 1920;
            //  vppOutHeight = 1080;
            bool doResize = true;
            if (doResize)
            {
            }else
            {

            }
            vppOutWidth = decVideoParam.mfx.FrameInfo.CropW;  // HxW of actual bitstream
            vppOutHeight = decVideoParam.mfx.FrameInfo.CropH;

            //resizing setup
            vppOutWidth = decVideoParam.mfx.FrameInfo.CropW / 4;
            vppOutHeight = decVideoParam.mfx.FrameInfo.CropH / 4;

            Console.WriteLine($"VPP output -- width {0} height {1}",
            vppOutWidth,
             vppOutHeight);

            vppVideoParam.vpp.Out.FourCC = FourCC.RGB4;
            vppVideoParam.vpp.Out.CropW = (ushort)(vppOutWidth);
            vppVideoParam.vpp.Out.CropH = (ushort)(vppOutHeight);

            var form = new SharpDX.Windows.RenderForm();


            form.Width = vppOutWidth; form.Height = vppOutHeight;  // use resized HxW
            form.Width = decVideoParam.mfx.FrameInfo.CropW; form.Height = decVideoParam.mfx.FrameInfo.CropH;  // use original HxW

            Console.WriteLine($"vppOutWidth {vppOutWidth}  vppOutHeight {vppOutHeight}");
            Console.WriteLine($"form.Width {form.Width}  form.Height {form.Height}");




            var impl = mfxIMPL.MFX_IMPL_VIA_D3D11 | mfxIMPL.MFX_IMPL_HARDWARE;

            var decoder = new StreamDecoder(s, decVideoParam, vppVideoParam, impl);
            //string impltext = QuickSyncStatic.ImplementationString(decoder.lowLevelDecoder.session);
            //Console.WriteLine("Implementation = {0}", impltext);
            //string memtext = QuickSyncStatic.ImplementationString(decoder.lowLevelDecoder.deviceSetup.memType);
            //Console.WriteLine("Memory type = {0}", memtext);


            if (useSystemMemoryNotVideoMemory)
            {
                device = new SharpDX.Direct3D11.Device(DriverType.Hardware);
            }
            else
            {
                IntPtr dx11device = decoder.lowLevelDecoder.videoAccelerationSupport.DeviceGetHandle(mfxHandleType.MFX_HANDLE_D3D11_DEVICE);
                device = new SharpDX.Direct3D11.Device(dx11device);
            }






            var fps = new FPSCounter();






            var sd = new SwapChainDescription()
            {
                BufferCount = 1,
                ModeDescription = new ModeDescription(vppOutWidth, vppOutHeight, new Rational(60, 1), Format.B8G8R8A8_UNorm),
                IsWindowed = true,
                OutputHandle = form.Handle,
                SampleDescription = new SampleDescription(1, 0),
                SwapEffect = SwapEffect.Discard,
                Usage = Usage.RenderTargetOutput,
                Flags = SwapChainFlags.None
            };

            var a = device.QueryInterface<SharpDX.DXGI.Device>();
            var b = a.Adapter.QueryInterface<Adapter2>();
            var c = b.GetParent<Factory2>();

            swapChain = new SwapChain(c, device, sd);


            var enumerator = decoder.GetFrames().GetEnumerator();

            RenderLoop.Run(form, () =>
            {
                enumerator.MoveNext();
                RenderFrameX(decoder, enumerator.Current);
                fps.PrintFPS();
            });


            swapChain.Dispose();
            device.Dispose();

        }




        private static void RenderFrameX(StreamDecoder d, mfxFrameSurface1 surf)
        {
            var m_pDXGIBackBuffer = swapChain.GetBackBuffer<Texture2D>(0);

            if (useSystemMemoryNotVideoMemory)
            {
                Trace.Assert(surf.Data.B != IntPtr.Zero);

                //ResourceRegion? rr = new ResourceRegion(0, 0, 0, 1920, 1080, 1);
                ResourceRegion? rr = null;
                device.ImmediateContext.UpdateSubresource(m_pDXGIBackBuffer, 0, rr, surf.Data.B, surf.Data.Pitch, 0);

            }
            else
            {
                Trace.Assert(surf.Data.MemId != IntPtr.Zero);

                IntPtr dx11frameHandle = d.lowLevelDecoder.videoAccelerationSupport.FrameGetHandle(surf.Data.MemId);
                //  CustomMemId* cm = (CustomMemId*)
                var texture2d = new Texture2D(dx11frameHandle);
                device.ImmediateContext.CopySubresourceRegion(texture2d, 0, null, m_pDXGIBackBuffer, 0);
            }

            swapChain.Present(2, PresentFlags.None);
        }
    }
}
