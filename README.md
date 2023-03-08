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

DeepL offers a Windows client for their regular translation services, but it doesn't support the API. Using the API can be more efficient for both the free and pro subscriptions: the free subscription offers 500.000 characters per month, which can be used for both documents and text. The pro subscription charges per character, instead of having to pay a set price monthly regardless of usage.

Personally I'm not a fan of their Windows client as it is, so I decided to write a quick API client I'd want to use, but ended up with a complete application - so decided to share here. Might be of use :)

Note: regardless of how it may seem, I'm not affiliated with DeepL in any way. I did not get a dime for writing this. If you appreciate my work, I'd appreciate a coffee! 

[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/lab02research)

----

### Usage

Just install the [latest installer](https://github.com/LAB02-Research/DeepL-Translator/releases/latest/download/DeepL.Translator.Installer.exe). The application will launch when done, and notify you of a missing API key.

You can get your free or pro key here: [https://www.deepl.com/pro-api?cta=header-pro-api/](https://www.deepl.com/pro-api?cta=header-pro-api/).

Make sure you set the correct domain, corresponding to your subscription:

![image](https://user-images.githubusercontent.com/81011038/223758959-bdb686b0-8d4b-48e5-be8e-b0707bfbfc82.png)

----

### Functionality

Summary of the core functions:

* **Text**: translate text, written or just drag a .txt file to the text field. Supports automatic language detection.

* **Documents**: translate a variaty of documents. Has lots of checks to make sure your document will be accepted by DeepL.

* **Formality**: supports setting a different formality (as long as the language supports it).

* **Cost management**: tells you how much your text or document will cost in terms of both characters and hard cash. Shows the current state of your subscription.

* **UI**: full fledged interface, built to be as easy to use as possible with as little clicks/keys as possible. Resides in the system tray.

* **Updater**: contains an automatic updater that'll keep your version up-to-date without any hassle.

----

### Screenshots

Text interface:

![image](https://user-images.githubusercontent.com/81011038/223756300-bd793d47-fe59-49de-9fe9-04d84af94273.png)

Document interface:

![image](https://user-images.githubusercontent.com/81011038/223756707-8db03b8e-d23e-4b97-9deb-e5c714f6de69.png)

You'll be notified of the costs before translating a document (note that this is a complete book, hence the huge amount of characters):

![image](https://user-images.githubusercontent.com/81011038/223756788-7a7ed293-4bf1-49ac-a76f-e409cd990730.png)

Easily check your subscription's state:

![image](https://user-images.githubusercontent.com/81011038/223756881-fdcc7444-de81-4fc3-a7e4-6db40bc26004.png)

Formality support:

![image](https://user-images.githubusercontent.com/81011038/223770387-4b158878-fd43-452b-9f39-4661fc24efd2.png)

----

### Todo

- Auto launch on Windows login
- Allow only single instance
- Send weekly usage logs to specified mailbox
- Domain info popup
- UI stays locked after 'translation failed'
- Press 'esc' in main window to hide
- Hide money cost on free subscription
- Show warning when limit passed
- Show warning when limit will be passed by translation
- Fix icon on dark backgrounds
- Change 'account' to 'subscription'
- Support both free and pro subscription at the same time, switching to pro after 500k chars

----

### Credits and Licensing

Thanks to DeepL for provided such a great translation service!

This project uses various opensource projects, please consult their individual licensing if you plan to use any of their code.

DeepL Translator released under the [MIT license](https://opensource.org/licenses/MIT).

LAB02 Research is not in any way affiliated to DeepL, and does not receive any commisions or other payment for developing this application.

---
