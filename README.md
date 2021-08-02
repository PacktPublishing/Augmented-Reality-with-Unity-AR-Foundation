# Augmented-Reality-with-Unity-AR-Foundation

Augmented Reality with Unity AR Foundation,
author, Jonathan Linowes, jonathan@parkerhill.com
published by Packt

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

### Suggested Third Pary Assets:

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
