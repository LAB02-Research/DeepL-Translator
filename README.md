[![GitHub release (latest by date)](https://img.shields.io/github/v/release/LAB02-Research/DeepL-Translator)](https://github.com/LAB02-Research/DeepL-Translator/releases/)
[![license](https://img.shields.io/badge/license-MIT-blue)](#license)
[![OS - Windows](https://img.shields.io/badge/OS-Windows-blue?logo=windows&logoColor=white)](https://www.microsoft.com/ "Go to Microsoft homepage")
[![dotnet](https://img.shields.io/badge/.NET-7.0-blue)](https://img.shields.io/badge/.NET-7.0-blue)
![GitHub all releases](https://img.shields.io/github/downloads/LAB02-Research/DeepL-Translator/total?color=blue)

<a href="https://github.com/LAB02-Research/DeepL-Translator/">
    <img src="https://github.com/LAB02-Research/DeepL-Translator/raw/main/images/logo_notext.png" alt="DeepL logo" title="DeepL" align="right" height="128" /></a>

# DeepL Translator

DeepL Translator is a Windows-based client application for [DeepL's translation API](https://www.deepl.com/pro-api?cta=header-pro-api), developed in .NET 7.

Click [here](https://github.com/LAB02-Research/DeepL-Translator/releases/latest/download/DeepL.Translator.Installer.exe) to download the latest installer.

----

### Content

 * [Introduction](#introduction)
 * [Download](#download)
 * [Functionality](#functionality)
 * [Usage](#usage)
 * [Screenshots](#screenshots)
 * [Implemented](#implemented)
 * [Credits and Licensing](#credits-and-licensing)

----

### Introduction

[DeepL](https://www.deepl.com/pro-api) provides AI/ML translation services. They differ from for example Google Translate in that they don't translate *as-is*, but also contextually. I've been using it a lot for translating from and into French, and it's truly amazing what they can do. Besides plain text, it's also possible to translate entire documents, while preserving their layout.

<p align="center">
<a href="https://www.deepl.com/pro-api/">
    <img src="https://github.com/LAB02-Research/DeepL-Translator/raw/main/images/deepl_full_logo.png" alt="DeepL logo" title="DeepL" height="128" /></a>
</p>

DeepL offers a Windows app for their translation services, but that client doesn't support the API, only regular subscriptions. Using the API can be more cost efficient for both the free and pro subscriptions: the free subscription offers 500.000 characters per month, which can be used for both documents and text. The pro subscription charges per character, instead of having to pay a set price monthly regardless of usage.

So, since there isn't an API client available, I built one that I'd want to use. It even has a feature that DeepL doesn't yet provide: **translating webpages**! It uses Firefox's *reading mode* engine which not only makes it easier for you to read the translation, but also reduces the amount of characters.

**Note: regardless of how it may seem, I'm not affiliated with DeepL in any way. I did not get a dime for writing this.**
If you appreciate my work, I'd appreciate a coffee!

[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/lab02research)

----

### Download

Click [here](https://github.com/LAB02-Research/DeepL-Translator/releases/latest/download/DeepL.Translator.Installer.exe) to download the latest installer, or [here](https://github.com/LAB02-Research/DeepL-Translator/releases/latest/) for the zip package and source code.

----

### Functionality

* **Text**: translate written text, or just drag and drop a .txt file.

* **Documents**: translate a variaty of document types. Supports drag and drop, and has lots of checks to make sure your document will be accepted by DeepL.

* **Webpages**: translate any webpage. Extracts the relevant text to reduce the amount of characters and increase the readability.

* **Language detection**: all of the above options support automatic source language detection.

* **Hotkey**: easily consult the app by pressing your hotkey. If you have text selected, it'll be conveniently pasted into the source textbox. Select an url and it'll get translated on the webpage tab right away.

* **Formality**: supports setting a different formality (as long as the language supports it).

* **Cost management**: tells you how much your text or document will cost in terms of both characters and hard cash. Shows the current state of your subscription.

* **UI**: full fledged interface, built to be easy and intuitive to use with as little input as possible. Resides in the system tray.

* **Print or save**: print your translations, or store them locally for later reference.

* **Updater**: contains an automatic updater that'll keep your translator up-to-date in the background.

----

### Usage

Just install the [latest installer](https://github.com/LAB02-Research/DeepL-Translator/releases/latest/download/DeepL.Translator.Installer.exe). It'll make sure you have all the required prerequisites, and the application will launch when done (and notify you of a missing API key).

You can get your free or pro key here: [https://www.deepl.com/pro-api/](https://www.deepl.com/pro-api/)

Make sure you set the correct domain, corresponding to your subscription:

![image](https://user-images.githubusercontent.com/81011038/225697022-7adb0b3a-f2be-417f-8a14-f516253eff78.png)

**Note: if you use a pro subscription and a different currency than euros, make sure to set the correct price-per-character value.**

----

### Screenshots

*What's the point of open sourcing your software if you don't share screenshots ..*

Text interface:

![image](https://user-images.githubusercontent.com/81011038/228805991-3078c003-dc00-4eb2-be52-59902b0bc8a0.png)

Document interface:

![image](https://user-images.githubusercontent.com/81011038/228806150-87e997bc-ae37-4cd5-9cd1-08262619151d.png)

Webpage interface:

![image](https://user-images.githubusercontent.com/81011038/225082337-98a958df-109d-4536-a59c-c82f896cbd41.png)

![image](https://user-images.githubusercontent.com/81011038/225969909-95f3d2e3-235d-44b7-898b-6c4c508d27b4.png)

You'll be notified of the costs before translating a document:

![image](https://user-images.githubusercontent.com/81011038/225082514-5d73345a-1e4d-4e30-85f3-6eedfe9114f4.png)

![image](https://user-images.githubusercontent.com/81011038/225082586-eb3c6ada-7c28-49c4-81c9-d08498469ff5.png)

![image](https://user-images.githubusercontent.com/81011038/225082691-96a85ca7-6bc0-48a6-a3d3-d6eea768336f.png)

If a document or webpage translation will exceed your limit, you'll be notified as well:

![image](https://user-images.githubusercontent.com/81011038/225082718-046a7d04-76f0-4026-9d9e-aaf1fbef0ceb.png)

Or if you've already reached your limit:

![image](https://user-images.githubusercontent.com/81011038/225083048-44d79723-366a-455e-9a89-26eaee470227.png)

Easily check your subscription's state:

![image](https://user-images.githubusercontent.com/81011038/225083226-9b4efe83-d717-4da7-8eda-9c61553215ae.png)

![image](https://user-images.githubusercontent.com/81011038/225083250-0be21350-363c-432b-a498-d5bf18535281.png)

Formality support:

![image](https://user-images.githubusercontent.com/81011038/224790184-dfed63ef-b438-4d2e-8843-e4114d831f78.png)

Hides in your system tray, next to the clock:

![image](https://user-images.githubusercontent.com/81011038/224070094-6a396395-7d95-4b44-9246-341cd76d0d38.png)

----

### Implemented

This is a list of features and fixes that have so far been done:

- Make main window resizable
- Toggle button to switch source and target language
- 'Document in use' check
- Add scrollbars to text translation fields
- Apply theme to webpage reading mode scrollbars
- Button tooltips
- Limit nagging popups to max once
- Always on top
- Support for other currencies
- Recognize urls when using global hotkey, insert into webpage tab
- Add 'open in browser' button for translated webpage
- Support for drag 'n dropping URLs
- Add 'save translation' support
- Add 'print translation' support
- Global hotkey
- Fetch selection after using global hotkey
- Set focus to 'translate' button after selecting document
- Set focus to 'copy to clipboard' after translating text
- Fix scaling on non-default DPI modes
- Ignore 'characters left' for pro
- Emphasize 'limit (will be) reached' message with red
- Revert to 'text' page on hide
- Fix tray icon on dark backgrounds
- Auto launch on Windows login
- Domain info popup
- UI stays locked after 'translation failed'
- Allow only single instance
- Press 'esc' in any window to hide
- Set money cost to zero on free
- Show warning when limit passed
- Show warning when limit will be passed by translation
- Add 'clear' buttons
- Add 'open subscription' button to info page
- Improve installer graphics
- Bundle .NET 7 and WebView2 with installer

----

### Credits and Licensing

Thanks to [DeepL](https://www.deepl.com/pro-api) for providing such a great translation service!

And a big thank you to all other packages:

[ByteSize](https://github.com/omar/ByteSize), [DeepL.net](https://github.com/DeepLcom/deepl-dotnet), [Microsoft.Web.WebView2](https://learn.microsoft.com/en-us/microsoft-edge/webview2/), [Newtonsoft.Json](https://www.newtonsoft.com/json), [HotkeyListener](https://github.com/Willy-Kimura/HotkeyListener) (and [@ruffk](https://github.com/ruffk)'s [core version](https://github.com/ruffk/HotkeyListener)), [Serilog](https://github.com/serilog/serilog), [SmartReader](https://github.com/strumenta/SmartReader), [Syncfusion](https://www.syncfusion.com).

Please consult their individual licensing if you plan to use any of their code.

DeepL Translator is released under the [MIT license](https://opensource.org/licenses/MIT).

**LAB02 Research is not in any way affiliated with DeepL, and does not receive any commisions or other payment for developing this application.**

---
