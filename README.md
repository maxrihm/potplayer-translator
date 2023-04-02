## TV/Movie Subtitle Translator
This is a C# program that translates selected phrases from TV show or movie subtitles and saves them to an Excel file. This enables you to review them later or add them to an Anki deck for future learning. The program works best if you have dual subtitles - one in English and one in your native language. You can click on the word you want to translate, and it will bring up the translation. You can also translate the whole sentence by pressing the hotkey to see how it looks in machine translation.

The program creates a table that looks like this:
| Word          | English Dialogue Line                            | Second Subtitles Dialogue Line                   |
|---------------|--------------------------------------------------|--------------------------------------------------|
| apparently    | But apparently I've raised a great kid.          | Но, видимо, я воспитала отличного ребёнка.       |
| sophisticated | This is for the sophisticated palates            | Это всё для утончённых вкусов                    |
| taking on     | You taking on a new hobby I should know about?   | У тебя новое хобби, о котором мне следует знать? |
| take off      | [Tami] Well, I guess I could take off the parka. | Думаю, можно снять с него курточку.              |
| envoy         | special diplomatic envoy to Nigeria.             | в Нигерию от семейства Галлагеров.               |

### How to use
1. Clone this repository and open the project in Visual Studio.
2. Run the program.
3. Open the TV show or movie subtitles in a media player that supports dual subtitles.
4. Select the text you want to translate, and the program will show the translation.
5. If you want to translate the whole sentence, press the hotkey (set to F2 by default).
6. Click the "Add" button or use the hotkey to add the translation to the Excel file.

### How it works
The program uses the CefSharp library to embed a Chromium browser in the program's window. When you select text, the program copies it to the clipboard and sends it to the embedded browser, which uses Yandex.Translate to get the translation. The program then displays the translation in the appropriate textbox. When you press the hotkey, the program sends the selected text to Google Translate and displays the machine translation in the appropriate textbox.

The program uses the Microsoft Office Interop library to write to the Excel file.

### Demo
https://user-images.githubusercontent.com/79306299/229358657-ebd9d108-46a1-4e36-ac6c-2b4df8a943ee.mp4
