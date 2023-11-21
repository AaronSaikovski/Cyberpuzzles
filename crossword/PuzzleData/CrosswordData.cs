
////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     CrosswordData.cs                                      //
//      Authors:    Aaron Saikovski                                        //
//      Date:       31/10/2023                                            //
//      Purpose:    Gets Crossword puzzle data from a datasource.         //
//                                                                        //
////////////////////////////////////////////////////////////////////////////



namespace CyberPuzzles.Crossword.PuzzleData
{

    //TODO: Make into an API?
    public partial class CrosswordData
    {
        //ConfigurationManager configuration = builder.Configuration;
        
        // get datafile path
        //var myKeyValue = configuration["DatafilePath"];
        
        #region GetCrosswordData

        public static string GetCrosswordData()
        {
            ///////////////////////////////////////////////////////////////////
            //Testing stuff
            //
            // Parse Quick Crossword data set
            //while(!MrParser.parseData("645*QX000000*0909*0 0 1 1#6 0 1 4#3 2 1 6#0 3 1 8#3 5 1 11#0 6 1 13#0 8 1 15#4 8 1 16#1 0 2 2#4 0 2 3#6 0 2 4#8 0 2 5#3 2 2 6#5 2 2 7#7 4 2 9#0 5 2 10#4 5 2 12#2 6 2 14*Bread maker#Skill#Receive#Calm#Real#Taunts#Apple _ _ _#Midday meal#Irritate#Wealthy#Queen,King,_ _ _#Ballet skirt#Book of maps#100 make a dollar#Conjuring#Cease#Prison room#Length of life*BAKER#ART#ACCEPT#SOOTHE#ACTUAL#TEASES#PIE#LUNCH#ANNOY#RICH#ACE#TUTU#ATLAS#CENTS#MAGIC#STOP#CELL#AGE*ABCEGHIKLMNOPRSTUY*30 1 1 0 1 5*Use the clues to solve this crossword and earn CyberSilver. If you have not played our crosswords before and want help, then click the HELP button. Have fun!"));
            //while(!MrParser.parseData("750*QX000003*0909*0 0 1 1#5 0 1 4#0 2 1 7#5 2 1 8#3 3 1 9#0 4 1 10#5 4 1 12#2 5 1 14#0 6 1 15#5 6 1 16#0 8 1 17#5 8 1 18#1 0 2 2#3 0 2 3#6 0 2 5#8 0 2 6#5 2 2 8#0 4 2 10#2 4 2 11#7 4 2 13*Young sheep#Fret#Another spelling of Cola#Qualified#Dividing structure#Stamp of authenticity#Prison room#Note#Above#Restore health#Fathers#After due time#Love#Person in a noisy quarrel#Piece of furniture#Skateboard roller#Intoxicating beverage#Reprove#Alter#Smallest*LAMB#STEW#KOLA#ABLE#WALL#SEAL#CELL#MEMO#OVER#HEAL#DADS#LATE#ADORE#BRAWLER#TABLE#WHEEL#ALCOHOL#SCOLD#AMEND#LEAST*LBCDEHKAMNORSTVW*30 1 1 0 1 5*Use the clues to solve this crossword and earn CyberSilver. If you have not played our crosswords before and want help, then click the HELP button. Have fun!"));

            //while(!MrParser.parseData("645*QX000000*1111*0 0 1 1#6 0 1 4#3 2 1 6#0 3 1 8#3 5 1 11#0 6 1 13#0 8 1 15#4 8 1 16#1 0 2 2#4 0 2 3#6 0 2 4#8 0 2 5#3 2 2 6#5 2 2 7#7 4 2 9#0 5 2 10#4 5 2 12#2 6 2 14*Bread maker#Skill#Receive#Calm#Real#Taunts#Apple _ _ _#Midday meal#Irritate#Wealthy#Queen,King,__ __ __#Ballet skirt#Book of maps#100 make a dollar#Conjuring#Cease#Prison room#Length of life*BAKER#ART#ACCEPT#SOOTHE#ACTUAL#TEASES#PIE#LUNCH#ANNOY#RICH#ACE#TUTU#ATLAS#CENTS#MAGIC#STOP#CELL#AGE*ABCEGHIKLMNOPRSTUY*30 1 1 0 1 5*Use the clues to solve this crossword and earn CyberSilver. If you have not played our crosswords before and want help, then click the HELP button. Have fun!"));

            // Parse TV Crossword data set
            //while(!MrParser.parseData("2542*TX000000*1515*0 0 1 1#6 0 1 3#0 2 1 8#11 2 1 9#0 4 1 11#9 5 1 14#4 6 1 17#0 7 1 19#10 7 1 21#6 8 1 23#0 9 1 24#6 10 1 26#0 12 1 30#5 12 1 31#0 14 1 32#10 14 1 33#0 0 2 1#4 0 2 2#7 0 2 4#9 0 2 5#11 0 2 6#14 0 2 7#13 2 2 10#2 4 2 12#6 4 2 13#14 5 2 15#0 6 2 16#8 6 2 18#3 7 2 20#10 7 2 21#12 7 2 22#1 9 2 25#7 10 2 27#14 10 2 28#5 11 2 29#0 12 2 30*Humphrey Bogart classic: 'The _ _ _ _ _ Mutiny'.#Actor in the series 'Skirts'.#Character played by Warren Mitchell in 15 down.#Actor in 'Dr Quinn:Medicine Woman': _ _ _ _ Allen.#Film about the mafia: 'The _ _ _ _ _ _ _ _ _'.#Occupation of one of the fathers in 'My Two Dads'.#Who starred as Mr Humphries in 'Are You Being Served?'. First name is John.#Richard Harris/Bo Derek feature: 'Orca/The Killer _ _ _ _ _'.#Sally Field feature about a woman with 16 personalities.#Character played by Luke Halpin in 'Flipper'. First name was Sandy.#At what game was Pat Cash very good?#Hosted the 'The Midday Show'.#Show with Robert Culp: 'The Greatest American _ _ _ _'.#'Home And Away' actor who played Shannon.#Character played by Woody Harrelson in the series 'Cheers'.#Talk show host: _ _ _ _ _ Winfrey.#Actor in 'Nanny'. (Last name)#Actor in 'How The West Was Won'. Last name is Saint.#He played Superman in the film of the same name. (Last name)#Clint Eastwood and Burt Reynolds film: '_ _ _ _ Heat'.#One of the puppets introduced by Edgar Bergen. First name was Charlie.#'General Hospital' character: _ _ _ Ashton.#Science fiction feature: 'Planet Of The _ _ _ _'.#Brent Spiner character in 'Star Trek'.#One of 'The Simpsons'. (First name)#Comedy series starring Warren Mitchell: '_ _ _ _ Death Us Do Part'.#Played Hot Lips Houlihan in 'M.A.S.H.'. (Last name)#'Full House' character: _ _ _ _ _ Katsopolis.#Occupation of Mr Roper in 'Three's Company'.#Mike Connors' cruise ship program.#Character played by Jack Kelly in 'Maverick'. (First name)#Singer: _ _ _ _ Adams.#Actor in 'Cheers'. First name is Kirstie.#American Civil War series:'_ _ _ _ _ And South'.#Surname ofthe Bee Gees.#Last name of the actor who played Roger Bannister in 'The Four Minute Mile'.*CAINE#TRACYMANN#ALFGARNETT#CHAD#GODFATHER#ARTIST#INMAN#WHALE#SYBIL#RICKS#TENNIS#RAYMARTIN#HERO#ISLAFISHER#WOODYBOYD#OPRAH#CRAIG#EVAMARIE#REEVE#CITY#MCCARTHY#NED#APES#DATA#HOMER#TILL#SWIT#NICKY#LANDLORD#SSCASINO#BART#EDIE#ALLEY#NORTH#GIBB#HUW*ABCDEFGHIKLMNOPRSTUVWY*30 1 1 0 1 5*Use the clues to solve this crossword and earn CyberSilver. If you have not played our crosswords before and want help, then click the HELP button. Have fun!"));
            //while(!MrParser.parseData("2617*TX000002*1515*5 0 1 3#10 0 1 5#0 1 1 8#7 2 1 9#0 3 1 11#7 4 1 13#0 5 1 14#6 6 1 17#0 7 1 19#10 7 1 20#4 8 1 21#9 9 1 22#0 10 1 24#6 11 1 26#4 12 1 29#9 13 1 30#0 14 1 31#6 14 1 32#0 0 2 1#2 0 2 2#5 0 2 3#7 0 2 4#10 0 2 5#12 0 2 6#14 0 2 7#8 2 2 10#3 3 2 12#0 5 2 14#2 5 2 15#4 5 2 16#6 6 2 17#14 6 2 18#9 9 2 22#11 9 2 23#0 10 2 24#7 10 2 25#12 11 2 27#14 11 2 28*Gil Gerard series: '_ _ _ _ Rogers In The 25th Century'.#Played a government agent in 'Get Smart'. (Last name)#Actor who starred in the film 'Star Wars'. (Last name)#Cartoon hero: _ _ _ _ Ant.#Actor in the series 'C.A.T.S. Eyes'.#She played Christine Francis in 'Hotel'. (Last name)#Was Cassie Barsby in 'Paradise Beach'. (Last name)#Jane Seymour series: 'Dr _ _ _ _ _: Medicine Woman'.#Was The Joker in the TV 'Batman'. (First name)#Talk show host. First name is Michael.#Was Amy Vining in 'General Hospital'. (First name)#Actor in the mini-series 'Roots'. First name was Vic.#Who played Carol Hathaway in 'E.R.'? (First name)#In 'The Last Resort', what was left to the daughters?#'Take 40 TV' host: _ _ _ _ Gaha.#Character in 'Police Rescue'. First name was Kathy.#Reg Varney series: 'On The _ _ _ _ _'.#Cartoon series : 'Quick _ _ _ _ McGraw'.#First name of the actor who played Sergeant Bilko.#Played Audrey Hardy in 21 across: Rachel _ _ _ _.#Actor in 'Baywatch': Yasmine _ _ _ _ _ _.#Movie with Michael Keaton: 'Working _ _ _ _ _ Man'.#In 'Happy Days', who played Al?#Damian Walshe Howling character in 'Blue Heelers'.#Character played by Jane Turner in 'Fast Forward'.#Police series set in Sun Hill Station.#Actor in the film 'Gorky Park'. Last name was Marvin.#Actor who played a misfit in 18 down. (First name)#Sherry Stringfield character in the 24 across series.#Roger Moore series: 'The _ _ _ _ _ _ _ _ _ _'.#Played Dolly in 'Certain Women': _ _ _ _ _ _ _ Ashton.#Film: 'One _ _ _ _ Over the Cuckoo's Nest'.#Robin Williams comedy: '_ _ _ _ _ _ On The Hudson'.#Nickname of Alf's daughter in 'Home And Away'.#Historian and TV personality: _ _ _ _ _ Bronowski.#He won an Emmy for 'Lou Grant': Ed _ _ _ _ _.#Actor in 'The Sweeney'. First name is John.#'Charlie's Angels' actor: Cheryl _ _ _ _.*BUCK#ADAMS#HAMILL#ATOM#LESLIEASH#SELLECCA#JOSEPH#QUINN#CESAR#ASPEL#SHELL#MORROW#JULIANNA#ISISHOTEL#EDEN#ORLAND#BUSES#DRAW#PHIL#AMES#BLEETH#CLASS#ALMOLINARO#ADAMCOOPER#SVETA#THEBILL#LEE#JACK#SUSANLEWIS#PERSUADERS#QUEENIE#FLEW#MOSCOW#ROO#JACOB#ASNER#THAW#LADD*AOTPERHISKLMNBDQFJCUVW*30 1 1 0 1 5*Use the clues to solve this crossword and earn CyberSilver. If you have not played our crosswords before and want help, then click the HELP button. Have fun!"));


            // Parse Junior Crossword data set
            //while(!MrParser.parseData("505*JX000000*0707*0 0 1 1#0 2 1 4#0 3 1 7#4 3 1 8#1 4 1 10#0 6 1 11#0 0 2 1#2 0 2 2#5 0 2 3#1 2 2 5#4 2 2 6#6 3 2 9*Try#Writing surface#Night bird#Truck#Opposite of male#Nearest#Car#Piece of furniture#Part of a flower#Terrible#Avoid#Unscramble XNET*ATTEMPT#TABLET#OWL#VAN#FEMALE#CLOSEST#AUTO#TABLE#PETAL#AWFUL#EVADE#NEXT*ABCDEFLMNOPSTUVWX*30 1 1 0 1 5*Use the clues to solve this crossword and earn CyberSilver. If you have not played our crosswords before and want help, then click the HELP button. Have fun!"));

            ///////////////////////////////////////////////////////////////////


            //// Specify the folder path

            string testPuzzleData;

            //TestPuzzleData = ReadRandomFile(folderPath);

            // Testing!
            //testPuzzleData = "761*QX000001*0909*0 0 1 1#4 1 1 6#0 2 1 7#2 3 1 9#0 5 1 11#4 6 1 16#0 7 1 17#4 8 1 18#0 0 2 1#2 0 2 2#4 0 2 3#6 0 2 4#8 0 2 5#3 2 2 8#5 3 2 10#0 5 2 11#2 5 2 12#4 5 2 13#6 5 2 14#8 5 2 15*Forward#Strictly accurate#Australian marsupial#Moving to avoid#Not accepted conduct#Astonish greatly#Provide meals#Occurrence#Pretend#Public way#Beer froth#Full-length dress#Adult male deer#Crazy#Metric unit of mass#Skin irritation#Friend#Uncommon#Inland body of water#Bench*FORTH#EXACT#KOALA#DODGING#IMMORAL#AMAZE#CATER#EVENT#FAKE#ROAD#HEAD#MAXI#STAG#LOCO#GRAM#ITCH#MATE#RARE#LAKE#SEAT*ZCDEFGHIKLMNORSTVXA*30 1 1 0 1 5*Use the clues to solve this crossword and earn CyberSilver. If you have not played our crosswords before and want help, then click the HELP button. Have fun!";

            testPuzzleData = "692*QX000004*0909*0 0 1 1#4 0 1 3#0 2 1 5#2 3 1 8#0 5 1 10#3 6 1 14#0 8 1 15#6 8 1 16#0 0 2 1#2 0 2 2#4 0 2 3#7 0 2 4#3 2 2 6#5 2 2 7#1 4 2 9#4 5 2 11#6 5 2 12#8 5 2 13*Drinking instrument#Commemorative badge#Tropical fruit#Digestibles#Made suitable#Test#Snake's poison#Produced by a chicken#3D square#Type of tree#Small#Behind#Modify to suit#Monastery#Love#Passenger vehicle#Completed#Adult male deer*CUP#MEDAL#BANANA#EDIBLES#ADAPTED#TRYOUT#VENOM#EGG#CUBE#PINE#MINI#AFTER#ADAPT#ABBEY#ADORE#TRAM#DONE#STAG*NCBEDFGILMAOPRSTUVY*30 1 1 0 1 5*Use the clues to solve this crossword and earn CyberSilver. If you have not played our crosswords before and want help, then click the HELP button. Have fun!";
            return testPuzzleData;
        }
        #endregion

        // Reads a random file from the filesystem
    }

}