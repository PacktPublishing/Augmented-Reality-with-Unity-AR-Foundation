# Augmented Reality with Unity AR Foundation

<a href="https://www.packtpub.com/product/augmented-reality-with-unity-ar-foundation/9781838982591"><img src="https://static.packt-cdn.com/products/9781838982591/cover/smaller" alt="Augmented Reality with Unity AR Foundation" height="256px" align="right"></a>

This is the code repository for [Augmented Reality with Unity AR Foundation](https://www.packtpub.com/product/augmented-reality-with-unity-ar-foundation/9781838982591), published by Packt.

**A practical guide to cross-platform AR development with Unity 2020 and later versions**

## What is this book about?
Augmented reality applications allow people to interact meaningfully with the real world through digitally enhanced content. Unity AR Foundation enables developers to create augmented reality applications and games for a variety of target devices. If you want to develop your own AR apps using Unity, AR Foundation is the most powerful and flexible platform you can use.

This book covers the following exciting features: 
* Discover Unity engine features for building AR applications and games
* Get up to speed with Unity AR Foundation components and the Unity API
* Build a variety of AR projects using best practices and important AR user experiences
* Understand core concepts of augmented reality technology and development for real-world projects
* Set up your system for AR development and learn to improve your development workflow

If you feel this book is for you, get your [copy](https://www.amazon.com/dp/1838982590) today!

<a href="https://www.packtpub.com/?utm_source=github&utm_medium=banner&utm_campaign=GitHubBanner"><img src="https://raw.githubusercontent.com/PacktPublishing/GitHub/master/GitHub.png" 
alt="https://www.packtpub.com/" border="5" /></a>


## Instructions and Navigations
All of the code is organized into folders. For example, Chapter02.

The code will look like the following:
```
public class TestInputSystem : MonoBehaviour
{
    private void Awake()
    {
        
    }
    public void OnPlaceObject(InputValue value)
    {
        Debug.Log("*** in OnPlaceObject");
    }
}
```

**Following is what you need for this book:**
This augmented reality book is for game developers interested in adding AR capabilities to their games and apps. The book assumes beginner-level knowledge of Unity development and C# programming, familiarity with 3D graphics, and experience in using existing AR applications. Beginner-level experience in developing mobile applications will be helpful to get the most out of this AR Unity book.

With the following software and hardware list you can run all code files present in the book (Chapter 1-9).

### Software and Hardware List

| Chapter  | Software required                   | OS required                        |
| -------- | ------------------------------------| -----------------------------------|
| 1-9       |  Unity 2020.3 LTS                 | Windows, Mac OS X, and Linux (Any) |


## Getting Started

This project was developed and tested using Unity 2020.3 LTS. For detailed set up instructions, see **Chapter 1, Setting Up for AR Development**, and **Chapter 4, Creating an AR User Framework: Getting Started**.

To begin, use the following steps:

1. Clone this repository to your local development machine, for example, using GitHub Desktop (https://desktop.github.com/), another GUI, or the Git command line interface.
2. Open the project in Unity 2020.3 LTS using **Unity Hub** (https://unity3d.com/get-unity/download).
3. Select **Ignore** if prompted to open in Safe Mode. Unity will import the project assets and required Unity packages dependencies that it can.

You will receive errors in the Console window due to missing third party packages that we cannot distribute on this GitHub repository. Continue with the following steps.

4. If you did not choose a Target Platform from Unity Hub, do it now using **File | Build Settings**, choose your target platform (Android or iOS) and select **Switch Platform**. Wait for the assets to re-import.
5. Open the Project Settings window (**Edit | Project Settings**) and ensure that XR Plug-In Management is installed and your target XR Plugin is selected (ARCore or ARKit)
6. Open the Package Manager (**Window | Package Manager**), select **Packages | In Project** (from the filter dropdown in the upper-left of the window) and verify that the project includes the following packages: Addressables, AR Foundation, ARCore XR Plugin (and/or ARKit XR Plugin), Input System, Localization, TextMeshPro, Universal RP, XR Plugin Management.
7. Import the free Serializable Dictionary Lite package from the Asset Store (https://assetstore.unity.com/packages/tools/utilities/serialized-dictionary-lite-110992) using Package Manager as prompted.
8. Import the free DOTween package from the Asset Store (https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676) using Package Manager as prompted. After import, the DOTween Utility Panel may open prompting you to **Setup DOTween...** and select **Apply**.

To verify your installation, build one of the chapter projects. For example, I suggest starting with the FrameworkDemo scene found in the \_ARFBookAssets/Chapter05/Scenes/ folder:

1. Open the Build Settings window (**File | Build Settings**), ensure the FrameworkDemo scene is checked in **Scenes In Build**, and none other scenes are checked.
2. Open the Player Settings window (**Edit | Project Settings | Player**) and ensure the settings are configured as required for your target device (see Chapter 1, Setting Up for AR Development or the online documentation for ARCore or ARKit and Unity).
3. Ensure your mobile device is set up for USB debugging, is connected to your computer, and is turned on.
4. Select **Build And Run**. Choose a location for the build files (I like using a Build/ folder in the project root)

If you encounter errors, please refer to the detailed instructions in Chapter 1, Setting Up for AR Development.

## Package dependencies

### Third Party Assets:

This project requires the following third-party asset packages:

- Serialized Dictionary Lite (free): https://assetstore.unity.com/packages/tools/utilities/serialized-dictionary-lite-110992
- DOTween (free): https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676

### Suggested Third Party Assets:

- Lunar Mobile Console (free): https://assetstore.unity.com/packages/p/lunar-mobile-console-free-82881
- AR Foundation Editor Remote ($$): https://assetstore.unity.com/packages/tools/utilities/ar-foundation-editor-remote-168773 (does not work with new Input System)

### Unity Packages Used:

If you clone this project, these packages will be automatically installed when you open the project because they're listed in the Packages folder. Otherwise if you're starting with your own project you may need to install them through Package Manager.

- AR Foundation
- ARCore XR Plugin and/or ARKit XR Plugin
- Input System
- TextMeshPro
- Universal RP
- XR Plugin Management

Onboarding UX dependencies:

- Addressables
- Localization


We also provide a PDF file that has color images of the screenshots/diagrams used in this book. [Click here to download it](https://static.packt-cdn.com/downloads/9781838982591_ColorImages.pdf).

### Related products <Other books you may enjoy>
* Game Development Patterns with Unity 2021 - Second Edition [[Packt]](https://www.packtpub.com/product/unity-2020-virtual-reality-projects-third-edition/9781839217333) [[Amazon]](https://www.amazon.com/dp/1800200811)

* Unity 2020 Virtual Reality Projects - Third Edition [[Packt]](https://www.packtpub.com/product/unity-2020-virtual-reality-projects-third-edition/9781839217333) [[Amazon]](https://www.amazon.com/dp/1839217332)

## Get to Know the Author
**Jonathan Linowes**
is a VR/AR enthusiast, Unity and full stack developer, entrepreneur, Certified Unity Instructor, and owner of Parkerhill XR Studio, an immersive media, applications, and game developer. Jonathan has a Bachelor of Fine Arts degree from Syracuse University, a Master of Science degree from the MIT Media Lab, and has held technical leadership positions at Autodesk and other companies. He has authored multiple books on VR and AR from Packt Publishing.

## Other books by the authors
* [Unity 2020 Virtual Reality Projects - Third Edition](https://www.packtpub.com/product/unity-2020-virtual-reality-projects-third-edition/9781839217333)	
* [Unity Virtual Reality Projects - Second Edition](https://www.packtpub.com/product/unity-virtual-reality-projects-second-edition/9781788478809)
* [Unity Virtual Reality Projects](https://www.packtpub.com/product/unity-virtual-reality-projects/9781783988556)
* [Augmented Reality for Developers](https://www.packtpub.com/product/augmented-reality-for-developers/9781787286436)
* [Cardboard VR Projects for Android](https://www.packtpub.com/product/cardboard-vr-projects-for-android/9781785887871)

### Download a free PDF

 <i>If you have already purchased a print or Kindle version of this book, you can get a DRM-free PDF version at no cost.<br>Simply click on the link to claim your free PDF.</i>
<p align="center"> <a href="https://packt.link/free-ebook/9781838982591">https://packt.link/free-ebook/9781838982591 </a> </p>