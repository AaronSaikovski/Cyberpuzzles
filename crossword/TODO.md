**CW.Net**

**TO DO**
2. Button for hint letters - clickedBtnGetLetter(int nCount)
3. Button for fetching next puzzle 
4. Credits/About screen 
5. API for fetching puzzle data from Storage account or Azure function?- allow for button to get next puzzle 
https://learn.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-dotnet?tabs=visual-studio%2Cmanaged-identity%2Croles-azure-portal%2Csign-in-azure-cli%2Cidentity-visual-studio
6. Add logging - Serilog - https://github.com/serilog/serilog

* Background graphics 
* Big refactor/Memory optimisation
* GitHub action for building X-Platform
* Test on windows
* Readme on how to build and deploy on Windows, Mac and Linux

**KNOWN BUGS**
* Font chars not centred in squares - parked for now
* Square repaint bug on keyboard/mouse navigation - investigating


**DONE**
* Mouse support - might need parent rectangle 
* ListBox event handlers
* Listbox Headers 
* Listboxes need to be positioned dynamically (X,Y)
* Fix listbox X,Y coords - make more dynamic
* * ListBox Font - how to change the font style - raised issue: https://github.com/rds1983/Myra/issues/432 - Resolved