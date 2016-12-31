# Reference Help Topics

## Intel Quick Sync Video
On most modern Intel consumer CPUs, and specific Xeon server CPUs, there is often an integrated GPU inside the CPU. The integrated GPU may act as a video card, and can provide video related functions.

In particular Intel's Quick Sync Video provides functionality for encoding, decoding, and transcoding of video elementary streams such as: 
- HEVC, H.265, AVC, H.264, MPEG-2, VP9, VC-1, MVC, JPEG, and MJPEG

The Lime Video SDK bring Quick Sync Video functions to languages like C#, F#, VB.NET on platforms that .NET can run on.

Throughout this documentation GPU will be used to refer to Intel's integrated GPU inside the CPU chip.

These links can provide some background on Intel Quick Sync Video, and Intel's graphic architecture:
https://en.wikipedia.org/wiki/Intel_Quick_Sync_Video
https://en.wikipedia.org/wiki/Intel_HD_and_Iris_Graphics
https://en.wikipedia.org/wiki/List_of_Intel_graphics_processing_units


## Linux Support [as of 12.29.2016]
We have had all the samples except the Windows/DirectX specific 'Player1' sample running on Linux under Mono. The current state of Linux support at the time of writing this is poor, as the samples should be re-tested, and included in a sample-level unit tests.
If you need Linux support, please contact me, as I would invest some time getting stuff ship-shape [in good condition] with an active end-user providing feedback. 

##Compressed Bitstream Formats
The Quick Sync hardware, and the SDK we use to access it, obstensibly provide support fort he following bitstream/elementary stream formats:
- HEVC, H.265, AVC, H.264, MPEG-2, VP9, VC-1, MVC, JPEG, and MJPEG<br>

But hardware bitstream support really depends upon which generation of Intel HD/Iris Graphics you are running on. If you are running on 9th, or 9.5th generation graphics you can fairly well expect to get hardware support for most formats in the above list. [9th and 9.5th Gen are found in Skylake and Kaby Lake CPUs]
As you go farther back in time you lose some levels of support, for example, Haswell has excellent support for H.264, but there is no or little support for H.265.
This section should be updated with a link to CPU/Intel-Graphics-Generation support by bitstream format if one is ever created or found.
This page talks about Intel Graphics Generations:
https://en.wikipedia.org/wiki/Intel_HD_and_Iris_Graphics


##Uncompressed FOURCC Formats 
FourCC formats are a system of naming and characterizing uncompressed video frame formats. Link: [Wiki-FourCC](https://en.wikipedia.org/wiki/FourCC)

Normally, "NV12" is the primary internal native format the Quick Sync Hardware uses.

There are two ways that FourCC formats may be converted:
- CPU based FourCC frame format conversion. [Link](#fourcc.conversion.cpu)
- GPU frame format conversion. [Link](#fourcc.conversion.gpu)




##Resizing Frames 
###Resizing during decoding
###Resizing in system memory
##Converting Frame Formats

<a name="fourcc.conversion.cpu"></a>
### CPU based FourCC frame format conversion
GPU based format conversion can be simpler to use than GPU format conversion, but can have the disadvantage of utilizing CPU cycles in situations where you are trying to use the CPU for other things.


<a name="fourcc.conversion.gpu"></a>
### GPU based FourCC frame format conversion
GPU based format conversion can have the advantage of higher performance, and little or no impact upon CPU utilization. It can be much tricker to use than CPU format conversion also.

The primary FourCC used by the GPU is NV12, the GPU can also convert NV12 to and from a number of other formats
Other FourCC formats, such as UYVY, RGB4, YUY2 are sometimes available for Quick Sync functions. Some of this may depend on your CPU/graphics-generation. Your ability to use this from the LVSDK will depend on the functions you use, and what has been supported.

You can use the [Player1 Sample](xref:samples#player1) to see how the sample configures the [StreamDecoder class](xref:LimeVideoSDKQuickSync.StreamDecoder) class to do GPU based conversion from the internal NV12 format to RGB4 format. This con
The @ provides 


<a name="imsdk"></a>
# Intel Media SDK Reference Documentation
The Lime Video SDK uses the Intel Media SDK to get access to the Quick Sync functions inside the CPU and GPU.
Sometimes it can be helpful to review the documentation for the low layer C++ SDK when using the Lime Video SDK.

Our preferred method for viewing the documentation is to download the latest version of the Intel Media SDK, install it,  and to find this file in the distribution: *mediasdk-man.pdf*

You might also find this link useful: https://software.intel.com/en-us/media-sdk/documentation
But our experience is that the online-reference documentation is incomplete, and we believe you will have a better experience with the PDF files from the SDK downloads.



# Lorem Ipsum
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vestibulum suscipit volutpat. Nullam ut neque pretium, viverra elit eu, semper eros. Maecenas in suscipit mi. Aliquam egestas lacus turpis, eget fermentum urna consectetur quis. Aliquam eget fermentum nibh. Donec et porttitor metus. Proin ultrices metus vel metus fringilla, ullamcorper lacinia massa lobortis.

Nam bibendum eleifend odio eu placerat. Vestibulum at ligula at turpis consequat dictum. Pellentesque fringilla accumsan blandit. Curabitur dictum lacinia mattis. Nulla auctor dolor a tortor condimentum dictum. Suspendisse at ultrices massa, vel congue turpis. Aenean facilisis lacinia ante vel finibus. Sed tellus turpis, consequat eget leo sed, congue porttitor purus. Etiam eget laoreet dolor. Integer tellus erat, congue at magna ac, elementum blandit elit. Suspendisse potenti.

Aenean velit mauris, rutrum in ex ut, fringilla ultricies risus. Maecenas feugiat gravida nunc vitae viverra. Aenean malesuada sollicitudin leo, eget tristique ex tincidunt ac. Vivamus luctus tortor nec tortor fringilla ultrices. Nulla elementum, nulla sed pellentesque tincidunt, nulla leo egestas massa, eget ornare dolor felis quis mi. Nunc sed eros feugiat, maximus lectus ut, tempor eros. In at auctor lacus. Pellentesque et mauris nisl. Sed bibendum libero eu auctor vehicula.

Sed ullamcorper mi sit amet turpis posuere consequat. Mauris rhoncus turpis quis justo ornare, at gravida libero iaculis. Nunc faucibus vel libero id placerat. Pellentesque massa velit, lobortis a faucibus at, suscipit vel felis. Aenean lacus nisi, dignissim in turpis eu, auctor dictum dui. Suspendisse at tortor nulla. Donec quis lorem vitae ante blandit pretium vel vitae purus. Proin lobortis nec est non porttitor. Morbi eget enim non est mollis scelerisque. Sed eu porta diam. Nullam aliquam, dui ut sodales posuere, mi erat facilisis eros, non commodo eros justo id lectus. Vivamus scelerisque erat eget elit commodo vulputate sed non enim. Donec fermentum mauris sit amet odio hendrerit tempus. Praesent eu pharetra nisl, sit amet lobortis orci. Phasellus ac fringilla odio, at fermentum nisl. Etiam sagittis tortor et blandit hendrerit.

Vivamus quis gravida nisi. Curabitur egestas gravida quam, vitae dignissim tortor lacinia nec. Phasellus facilisis dolor eu pellentesque placerat. Vestibulum ornare, nunc sed consequat tempus, magna libero placerat ex, sit amet finibus nisl mauris nec augue. Aenean vestibulum efficitur enim, sit amet convallis magna porttitor id. Nulla dictum consectetur ante, ac congue metus blandit non. Morbi lobortis orci eu quam dignissim, sit amet volutpat nisl rhoncus. Aliquam aliquet faucibus elit quis blandit. Nam lacinia sollicitudin laoreet. Aenean nisi libero, elementum a velit id, varius ultrices elit. Aliquam erat volutpat.

Vestibulum ut rhoncus ante, feugiat iaculis eros. Nam vel ex quis sapien rhoncus tristique. Sed consequat convallis massa eget euismod. Maecenas eget viverra leo, ac fermentum erat. Vivamus pretium libero orci, vitae pellentesque libero tempus at. Nulla consequat quam ut felis malesuada, ut dictum felis convallis. Donec eget nibh vel magna dignissim scelerisque non sit amet dolor. Cras at quam sed libero sodales condimentum. Morbi accumsan ligula ut odio luctus consectetur.

Ut porta mauris sed libero aliquet vehicula. Ut sit amet augue a lacus euismod varius. Vestibulum ullamcorper mattis fermentum. Nulla vehicula mollis porta. Nunc at elementum nulla. Vestibulum pulvinar, est viverra porttitor mollis, dolor turpis dapibus velit, eget euismod leo enim vitae nisi. Aliquam sit amet ex erat. Donec ut congue neque, ac mollis lorem. Quisque rhoncus in ante eu gravida. Mauris iaculis vehicula risus, a porta mauris semper eget. Suspendisse in mattis lacus. In ac semper risus.

Vivamus quis vulputate erat. Proin sed lorem faucibus, vulputate orci tristique, aliquet mauris. Nullam ornare semper sapien vel malesuada. Nunc eget mi ac massa blandit tempor. Fusce vitae velit et lacus viverra ultricies at a mi. In hac habitasse platea dictumst. Morbi porta ultrices nunc, eget ullamcorper dolor dictum eget. Pellentesque augue neque, varius vitae lacus quis, iaculis blandit nisi. Quisque nulla mauris, malesuada vitae mattis id, pulvinar et massa. Morbi neque mauris, luctus et vehicula quis, condimentum in eros. Etiam faucibus pulvinar blandit.

Suspendisse tempus urna ac efficitur ultrices. Cras porttitor lacus orci, ut sollicitudin velit imperdiet eu. Praesent laoreet et tortor quis gravida. Ut vel magna vulputate, pellentesque orci in, placerat leo. Donec ultrices, odio sit amet vestibulum elementum, odio dolor suscipit metus, vitae sodales odio augue eu sapien. Ut in dolor lacinia, venenatis mi vel, cursus augue. Nam ante lacus, congue volutpat venenatis in, fringilla ac arcu. Etiam dapibus dapibus scelerisque. Ut tellus justo, consequat at eros vitae, vestibulum tristique libero.

Praesent nec enim viverra, aliquet risus eu, feugiat lorem. Vestibulum euismod justo massa, quis accumsan dui volutpat sed. Nulla ut ullamcorper neque. Duis id enim diam. Pellentesque aliquam dui at placerat lobortis. Pellentesque ac augue nunc. Aliquam consectetur consectetur mi, ut viverra lectus pellentesque at. Mauris ultrices auctor enim, quis tempor urna egestas porttitor. Proin imperdiet molestie mauris at mollis. Duis ut dui aliquet, lacinia nisi eget, sodales neque. Phasellus et massa quam. Donec tristique vestibulum ante at malesuada. Morbi diam lacus, varius eget maximus sed, ultrices nec nisi. Donec molestie vitae lorem ut accumsan.

Sed vehicula, odio nec placerat scelerisque, leo dui feugiat magna, sed convallis felis quam lobortis ex. Mauris vel rhoncus massa. Fusce eget lobortis justo, nec pulvinar urna. Fusce scelerisque sem sed ante tempor, ut hendrerit lacus tristique. Suspendisse mattis leo vitae arcu maximus, vel congue massa consequat. Nam nisl tellus, mattis eu turpis eget, scelerisque varius diam. Pellentesque ac massa condimentum, facilisis sapien eget, lacinia orci. Vivamus justo ex, pulvinar ornare quam a, sodales laoreet tortor. Integer gravida, orci vitae pretium ultricies, ligula dui molestie dolor, ac bibendum tortor neque nec nisl. Pellentesque nec elementum enim. Integer quis nisl at massa efficitur sodales eget at neque. Integer a est hendrerit, tincidunt arcu at, venenatis nibh. Nam in elementum magna, vitae ornare ligula.

Maecenas sit amet mollis justo, at ultrices justo. Vestibulum suscipit porta nunc, bibendum vestibulum augue hendrerit tempor. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla finibus sem et ultrices vestibulum. Integer vitae viverra nibh. Proin et leo congue, iaculis tellus sed, tempus justo. Cras et nulla nec ante egestas finibus. Proin gravida tellus sapien, sed tempor ante vehicula et. Praesent mollis, nibh id eleifend rhoncus, mi ligula viverra elit, rhoncus tempus erat ligula non enim.

Ut placerat placerat ex vel condimentum. Sed vel ipsum felis. Etiam tempor turpis quis facilisis dignissim. Etiam eget rhoncus enim, a ullamcorper arcu. Praesent vitae odio sit amet nisl posuere efficitur quis et lectus. Proin facilisis sapien id ex lacinia imperdiet. Sed eleifend eu leo nec hendrerit. Donec et porta nunc. Duis interdum nisi enim, eu tristique tellus auctor eu. Nullam eu nisl eget velit scelerisque vulputate. Sed in ligula ac neque laoreet iaculis in a libero.

Pellentesque rutrum condimentum libero non efficitur. Fusce feugiat suscipit justo, at dapibus velit dapibus ac. Praesent nec dictum ex. Phasellus venenatis posuere eros vitae tincidunt. Sed et finibus orci, sed dapibus leo. Nunc quis orci molestie, aliquet turpis euismod, tincidunt augue. Aliquam efficitur ligula enim, dignissim mollis diam congue vitae. Maecenas pretium pellentesque magna, at auctor quam auctor nec. Praesent congue sollicitudin urna, luctus malesuada ante fringilla id. Nunc suscipit, ipsum consectetur scelerisque dictum, dui leo posuere turpis, id posuere dui dolor nec mi. Aliquam tincidunt dolor non consequat ultrices.

Donec et molestie augue, venenatis ullamcorper nisl. Curabitur dignissim suscipit sem a tempor. Donec maximus, sem non sodales venenatis, lectus augue aliquet nibh, nec finibus turpis elit ac ipsum. Nulla ultrices nulla turpis, quis vulputate mi scelerisque in. Curabitur molestie porta varius. Curabitur pulvinar ex in purus dictum congue. Integer vitae dui quis velit venenatis vestibulum. In placerat, nibh a tempus bibendum, diam orci lacinia nulla, quis pulvinar tellus dolor ultrices quam.

In volutpat quam non tempus tincidunt. Ut eu neque in diam varius facilisis. Donec vitae lobortis risus. Nullam dapibus, lorem nec faucibus luctus, augue quam tincidunt tellus, non interdum ante nisl sed tellus. Donec porttitor sit amet turpis vitae molestie. Vestibulum orci sem, molestie at mauris ac, egestas tempor nisi. Proin consectetur rutrum metus, id interdum erat pulvinar at. Sed tristique vulputate sapien, eu egestas erat aliquam tempor. Morbi fermentum placerat magna, id consectetur sem accumsan id. Donec suscipit felis eu ultricies tristique. Aliquam hendrerit ipsum velit, ut efficitur urna pharetra eget. Maecenas cursus scelerisque ornare. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Proin hendrerit lorem tellus, et placerat quam ultricies ac. Nam id justo id velit placerat fringilla.

Morbi ut arcu dictum, blandit leo posuere, lacinia massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nunc porta, nisi sed porta facilisis, elit lectus ullamcorper nisi, sit amet tempus arcu odio ac enim. Vestibulum a mollis risus. Nam tristique sapien a lorem molestie finibus. Proin vitae congue tortor. Pellentesque in finibus quam. Cras libero erat, ullamcorper eget vestibulum quis, varius eget magna. Praesent accumsan interdum nisl sed dignissim. Duis auctor, neque placerat viverra vulputate, massa est hendrerit augue, eu eleifend sem mauris sit amet lectus. Proin dapibus ac magna non tincidunt.

Sed elementum dignissim arcu ac lobortis. Suspendisse at lorem mi. Phasellus interdum tellus sed mi facilisis viverra. In quis faucibus nulla, sed ultrices urna. Vivamus mollis arcu sed lacus varius blandit. Fusce consequat purus nec dui scelerisque, id scelerisque ex viverra. Fusce venenatis semper purus ac faucibus. Duis in lectus sed urna mattis sagittis nec sodales dolor. Quisque malesuada magna in massa dapibus scelerisque convallis a magna. Vivamus euismod, metus vel vulputate pretium, nisl mauris porttitor mi, pellentesque rutrum eros ligula non nibh. Proin placerat ante a imperdiet placerat. Ut a metus dapibus, iaculis orci vel, aliquet purus.

Fusce vehicula efficitur arcu, efficitur interdum lacus suscipit eu. In eu mattis ex, quis iaculis elit. Aenean quis dui vitae nisi varius tempor. Aliquam eu tincidunt metus, nec ultricies augue. Praesent sem eros, porta non egestas ac, sodales et ante. Nam quis ipsum ex. Vivamus convallis dapibus est, nec vulputate arcu porttitor nec. Sed varius nulla porta sapien gravida, a efficitur ex scelerisque. Sed consequat vulputate scelerisque. Nullam feugiat erat vel sem posuere, eget efficitur tortor luctus. Fusce eu sem iaculis, efficitur felis sit amet, dignissim est. Curabitur ultricies sed ante sit amet ultricies. Nullam vel placerat velit. Quisque sollicitudin massa in faucibus aliquet. Donec congue euismod massa vel volutpat. Donec orci nulla, tristique vel bibendum sit amet, bibendum at eros.

In scelerisque diam at enim auctor, fermentum lobortis eros accumsan. Ut blandit et nisl at auctor. Fusce rutrum neque dui, ac maximus sem feugiat id. Mauris et mauris augue. Phasellus vitae nisi ut quam ultricies sodales at vel massa. Proin tincidunt diam vitae est tristique volutpat feugiat pulvinar dolor. Nullam vel tellus gravida, cursus arcu eu, mattis sapien. Sed ut tortor blandit, euismod enim in, malesuada sem. Sed iaculis nisl at orci commodo dictum. Donec a est vel lacus facilisis gravida elementum in purus. Donec gravida ornare quam ac dignissim. Vivamus aliquam urna sed dictum luctus. Vivamus ac sodales dui. In sit amet pharetra felis, sit amet vehicula leo. Proin tincidunt eros consectetur elit vehicula ornare.