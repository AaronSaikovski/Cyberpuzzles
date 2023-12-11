**CW.Net**

**TO DO**
* Fix bBufferDirty state machine redraw bug - causing weird redraw issues
* GitHub action for building X-Platform
* Test on windows
* Readme on how to build and deploy on Windows, Mac and Linux
* Credits/About screen - https://github.com/Byron1c/MonoGame-Game-Menu



**ON HOLD**
* Background graphics

* Dockerfile for API service 
* Add unit test 
* Big refactor/Memory optimisation
* add animated push buttons

**KNOWN BUGS**
* Font chars not centred in squares
* Square repaint bug on keyboard/mouse navigation - investigating
* ListBox event handlers - BUG


**DONE**
* Mouse support - might need parent rectangle
* Logging via serilog
* add black line spacers between puzzle squares - refer to updateBackBuffer()
* add ArgumentNullException.ThrowIfNull(param) to methods - guard clauses.
* * big, Chunky square graphics - or remove images and just make white squares with black text?
* Added basic API support
* Button for hint letters - clickedBtnGetLetter(int nCount)
* Listbox Headers 
* Button for fetching next puzzle - calls API
* Listboxes need to be positioned dynamically (X,Y)
* Fix listbox X,Y coords - make more dynamic 
* ListBox Font - how to change the font style - raised issue: https://github.com/rds1983/Myra/issues/432 - Resolved 
* implement API key for better security https://www.c-sharpcorner.com/article/using-api-key-authentication-to-secure-asp-net-core-web-api/
* add buttons for hints and get next puzzle link buttons.