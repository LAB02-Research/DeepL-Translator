[![GitHub release (latest by date)](https://img.shields.io/github/v/release/LAB02-Research/DeepL-Translator)](https://github.com/LAB02-Research/DeepL-Translator/releases/)
[![license](https://img.shields.io/badge/license-MIT-blue)](#license)
[![OS - Windows](https://img.shields.io/badge/OS-Windows-blue?logo=windows&logoColor=white)](https://www.microsoft.com/ "Go to Microsoft homepage")
[![dotnet](https://img.shields.io/badge/.NET-7.0-blue)](https://img.shields.io/badge/.NET-7.0-blue)

<a href="https://github.com/LAB02-Research/DeepL-Translator/">
    <img src="https://github.com/LAB02-Research/DeepL-Translator/raw/main/images/logo_notext.png" alt="DeepL logo" title="DeepL" align="right" height="128" /></a>

# DeepL Translator

DeepL Translator is a Windows-based client application for [DeepL's translation API](https://www.deepl.com/pro-api?cta=header-pro-api), developed in .NET 7.

Click [here](https://github.com/LAB02-Research/DeepL-Translator/releases/latest/download/DeepL.Translator.Installer.exe) to download the latest installer.

----

### Contents

 * [Why?](#why)
 * [Usage](#usage)
 * [Functionality](#functionality)
 * [Screenshots](#screenshots)
 * [Todo](#todo)
 * [Credits and Licensing](#credits-and-licensing)

----

### Why?

[DeepL](https://deepl.com) provides AI/ML translation services. It differs from for example Google Translate in that it doesn't translate sec, but also contextually. I've been using it a lot for translating from and into French, and it's truly amazing what it can do. They also allow the translation of documents, preserving the layout in the process.

DeepL offers a Windows client for their regular translation services, but it doesn't support the API. Using the API can be more cost efficient for both the free and pro subscriptions: the free subscription offers 500.000 characters per month, which can be used for both documents and text. The pro subscription charges per character, instead of having to pay a set price monthly regardless of usage.

Personally I'm not a fan of their Windows client as it is, so I decided to write a quick API client I'd want to use. Ended up with a complete application - so decided to share here. Might be of use :)

Note: regardless of how it may seem, I'm not affiliated with DeepL in any way. I did not get a dime for writing this. If you appreciate my work, I'd appreciate a coffee! 

[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/lab02research)

----

### Usage

Just install the [latest installer](https://github.com/LAB02-Research/DeepL-Translator/releases/latest/download/DeepL.Translator.Installer.exe). The application will launch when done, and notify you of a missing API key.

You can get your free or pro key here: [https://www.deepl.com/pro-api?cta=header-pro-api/](https://www.deepl.com/pro-api?cta=header-pro-api/).

Make sure you set the correct domain, corresponding to your subscription:

![image](https://user-images.githubusercontent.com/81011038/224070374-8d0b28f0-13ba-469f-a1be-6f630750280a.png)

----

### Functionality

Summary of the core functions:

* **Text**: translate text, written or just drag a .txt file to the text field. Supports automatic language detection.

* **Documents**: translate a variaty of documents. Has lots of checks to make sure your document will be accepted by DeepL.

* **Formality**: supports setting a different formality (as long as the language supports it).

* **Cost management**: tells you how much your text or document will cost in terms of both characters and hard cash. Shows the current state of your subscription.

* **UI**: full fledged interface, built to be easy and intuitive to use with as little clicks/keys as possible. Resides in the system tray.

* **Updater**: contains an automatic updater that'll keep your version up-to-date without any hassle.

----

### Screenshots

Text interface:

![image](https://user-images.githubusercontent.com/81011038/224069592-55b7f95f-cc76-41d0-b422-938dcda08e43.png)

Document interface:

![image](https://user-images.githubusercontent.com/81011038/224069650-cb5e8935-ad74-4799-8fe3-72515556b0ca.png)

You'll be notified of the costs before translating a document:

![image](https://user-images.githubusercontent.com/81011038/224069716-131833e9-82d8-497f-a2b4-80da5b482fcd.png)

![image](https://user-images.githubusercontent.com/81011038/224288107-98c65c5f-3a57-4346-a398-d6b0d29fe637.png)

If a translation will exceed your limit, you'll be notified as well:

![image](https://user-images.githubusercontent.com/81011038/224287457-c5f300a0-290b-472f-8a77-8decbbb4de04.png)

Or if you've already reached your limit:

![image](https://user-images.githubusercontent.com/81011038/224287843-6320232c-cdae-465d-90d5-ee56a281582e.png)

Easily check your subscription's state:

![image](https://user-images.githubusercontent.com/81011038/224290688-7d464c33-5d64-4704-be9b-615d3f553d9b.png)

![image](https://user-images.githubusercontent.com/81011038/224290855-48c2e721-4a59-4467-becf-cda1a4ba06a5.png)

Formality support:

![image](https://user-images.githubusercontent.com/81011038/223770387-4b158878-fd43-452b-9f39-4661fc24efd2.png)

Hides in your system tray, next to the clock:

![image](https://user-images.githubusercontent.com/81011038/224070094-6a396395-7d95-4b44-9246-341cd76d0d38.png)

----

### Todo

- Set focus to 'translate' button after selecting document
- Set focus to 'source' after translating document
- Send weekly usage logs
- Global hotkeys
- Fetch selection after using global hotkey
- Text ranslations history
- Emphasize 'limit (will be) reached' message with red
- ~~Fix icon on dark backgrounds~~
- ~~Auto launch on Windows login~~
- ~~Domain info popup~~
- ~~UI stays locked after 'translation failed'~~
- ~~Allow only single instance~~
- ~~Press 'esc' in main window to hide~~
- ~~Set money cost to 0,00 on free~~
- ~~Show warning when limit passed~~
- ~~Show warning when limit will be passed by translation~~
- ~~Add 'clear' buttons to both pages~~
- ~~Add 'open subscription' button to info page~~
- ~~Improve installer graphics~~

----

### Credits and Licensing

Thanks to DeepL for provided such a great translation service!

This project uses various opensource projects, please consult their individual licensing if you plan to use any of their code.

DeepL Translator released under the [MIT license](https://opensource.org/licenses/MIT).

LAB02 Research is not in any way affiliated to DeepL, and does not receive any commisions or other payment for developing this application.

---
