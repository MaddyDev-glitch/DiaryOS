
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Sys = Cosmos.System;
using static MIV.MIV;

namespace MIV
{
    class MIV
    {
        public const int POS = 1;
        public const int NEG = -1;

        public static void Home()
        {
            Console.Clear();
            Console.WriteLine("                                        Diary OS");
            Console.WriteLine("");
            Console.WriteLine("                                           Home");
            Console.WriteLine("                                            by ");
            Console.WriteLine("                  by T Srimadhaven | Bettina Shirley R | Chris Junni AV");
            Console.WriteLine("                              Save /edit/view files working ");
            Console.WriteLine("");
            Console.WriteLine("                      type :1<Enter>             Enter file name");
            Console.WriteLine("                      type :2<Enter>             to view existing files");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.Write("--------------------------------------------------------------------------------");
            var homech = Console.ReadLine();
            if (homech == "1")
            {
                StartMIV();
            }
            else
            {
                Console.WriteLine("Entries: \n\n");
                var directory_list = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing("0:/");
                foreach (var directoryEntry in directory_list)
                {
                    System.Console.WriteLine(directoryEntry.mName);
                }
                Console.WriteLine("");
                StartMIV();
                Home();
            }
        }
        public static void printMIVStartScreen()
        {
            Console.Clear();
            Console.WriteLine("--");
            Console.WriteLine("--");
            Console.WriteLine("--");
            Console.WriteLine("--");
            Console.WriteLine("---");
            Console.WriteLine("--");
            Console.WriteLine("-");
            Console.WriteLine("                                        Diary OS");
            Console.WriteLine("");
            Console.WriteLine("                                     version 1.0 Beta");
            Console.WriteLine("                                            by ");
            Console.WriteLine("                  by T Srimadhaven | Bettina Shirley R | Chris Junni AV");
            Console.WriteLine("                              Save /edit/view files working ");
            Console.WriteLine("                     MIV is open source and freely distributable");
            Console.WriteLine("");
            Console.WriteLine("                      type :help<Enter>          for information");
            Console.WriteLine("                      type :q<Enter>             to exit");
            Console.WriteLine("                      type :wq<Enter>            save to file and exit");
            Console.WriteLine("                      press i                    to write");
            Console.WriteLine("                      type :ls                   to view list");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.Write("--------------------------------------------------------------------------------");
        }

        public static String stringCopy(String value)
        {
            String newString = String.Empty;

            for (int i = 0; i < value.Length - 1; i++)
            {
                newString += value[i];
            }

            return newString;
        }

        public static void printMIVScreen(char[] chars, int pos, String infoBar, Boolean editMode)
        {
            int countNewLine = 0;
            int countChars = 0;
            //delay(1);
            Console.Clear();

            for (int i = 0; i < pos; i++)
            {
                if (chars[i] == '\n')
                {
                    Console.WriteLine("");
                    countNewLine++;
                    countChars = 0;
                }
                else
                {
                    Console.Write(chars[i]);
                    countChars++;
                    if (countChars % 80 == 79)
                    {
                        countNewLine++;
                    }
                }
            }

            Console.Write("/");

            for (int i = 0; i < 23 - countNewLine; i++)
            {
                Console.WriteLine("");
                Console.Write("~");
            }

            //PRINT INSTRUCTION
            Console.WriteLine();
            for (int i = 0; i < 72; i++)
            {
                if (i < infoBar.Length)
                {
                    Console.Write(infoBar[i]);
                }
                else
                {
                    Console.Write(" ");
                }
            }

            if (editMode)
            {
                Console.Write(countNewLine + 1 + "," + countChars);
            }

        }
        public static String miv(String start)
        {
            Boolean editMode = false;
            int pos = 0;
            char[] chars = new char[2000];
            String infoBar = String.Empty;

            if (start == null)
            {
                printMIVStartScreen();
            }
            else
            {
                pos = start.Length;

                for (int i = 0; i < start.Length; i++)
                {
                    chars[i] = start[i];
                }
                printMIVScreen(chars, pos, infoBar, editMode);
            }

            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);

                if (isForbiddenKey(keyInfo.Key)) continue;

                else if (!editMode && keyInfo.KeyChar == ':')
                {
                    infoBar = ":";
                    printMIVScreen(chars, pos, infoBar, editMode);
                    do
                    {
                        keyInfo = Console.ReadKey(true);
                        if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            if (infoBar == ":wq")
                            {
                                String returnString = String.Empty;
                                for (int i = 0; i < pos; i++)
                                {
                                    returnString += chars[i];
                                }
                                return returnString;
                            }
                            else if (infoBar == ":ls")
                            {
                                Console.WriteLine("Entries: \n\n");
                                var directory_list = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing("0:/");
                                foreach (var directoryEntry in directory_list)
                                {
                                    System.Console.WriteLine(directoryEntry.mName);
                                }
                                StartMIV();
                                printMIVStartScreen();


                            }
                            else if (infoBar == ":q")
                            {
                                return null;

                            }
                            else if (infoBar == ":help")
                            {
                                printMIVStartScreen();
                                break;
                            }
                            else
                            {
                                infoBar = "ERROR: No such command";
                                printMIVScreen(chars, pos, infoBar, editMode);
                                break;
                            }
                        }
                        else if (keyInfo.Key == ConsoleKey.Backspace)
                        {
                            infoBar = stringCopy(infoBar);
                            printMIVScreen(chars, pos, infoBar, editMode);
                        }
                        else if (keyInfo.KeyChar == 'q')
                        {
                            infoBar += "q";
                        }
                        else if (keyInfo.KeyChar == ':')
                        {
                            infoBar += ":";
                        }
                        else if (keyInfo.KeyChar == 'w')
                        {
                            infoBar += "w";
                        }
                        else if (keyInfo.KeyChar == 'h')
                        {
                            infoBar += "h";
                        }
                        else if (keyInfo.KeyChar == 'e')
                        {
                            infoBar += "e";
                        }
                        else if (keyInfo.KeyChar == 'l')
                        {
                            infoBar += "l";
                        }
                        else if (keyInfo.KeyChar == 'p')
                        {
                            infoBar += "p";
                        }
                        else if (keyInfo.KeyChar == 's')
                        {
                            infoBar += "s";
                        }
                        else
                        {
                            continue;
                        }
                        printMIVScreen(chars, pos, infoBar, editMode);



                    } while (keyInfo.Key != ConsoleKey.Escape);
                }

                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    editMode = false;
                    infoBar = String.Empty;
                    printMIVScreen(chars, pos, infoBar, editMode);
                    continue;
                }

                else if (keyInfo.Key == ConsoleKey.I && !editMode)
                {
                    editMode = true;
                    infoBar = "-- INSERT --";
                    printMIVScreen(chars, pos, infoBar, editMode);
                    continue;
                }

                else if (keyInfo.Key == ConsoleKey.Enter && editMode && pos >= 0)
                {
                    chars[pos++] = '\n';
                    printMIVScreen(chars, pos, infoBar, editMode);
                    continue;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && editMode && pos >= 0)
                {
                    if (pos > 0) pos--;

                    chars[pos] = '\0';

                    printMIVScreen(chars, pos, infoBar, editMode);
                    continue;
                }

                if (editMode && pos >= 0)
                {
                    chars[pos++] = keyInfo.KeyChar;
                    printMIVScreen(chars, pos, infoBar, editMode);
                }
            } while (true);
        }

        public static bool isForbiddenKey(ConsoleKey key)
        {
            ConsoleKey[] forbiddenKeys = { ConsoleKey.Print, ConsoleKey.PrintScreen, ConsoleKey.Pause, ConsoleKey.Home, ConsoleKey.PageUp, ConsoleKey.PageDown, ConsoleKey.End, ConsoleKey.NumPad0, ConsoleKey.NumPad1, ConsoleKey.NumPad2, ConsoleKey.NumPad3, ConsoleKey.NumPad4, ConsoleKey.NumPad5, ConsoleKey.NumPad6, ConsoleKey.NumPad7, ConsoleKey.NumPad8, ConsoleKey.NumPad9, ConsoleKey.Insert, ConsoleKey.F1, ConsoleKey.F2, ConsoleKey.F3, ConsoleKey.F4, ConsoleKey.F5, ConsoleKey.F6, ConsoleKey.F7, ConsoleKey.F8, ConsoleKey.F9, ConsoleKey.F10, ConsoleKey.F11, ConsoleKey.F12, ConsoleKey.Add, ConsoleKey.Divide, ConsoleKey.Multiply, ConsoleKey.Subtract, ConsoleKey.LeftWindows, ConsoleKey.RightWindows };
            for (int i = 0; i < forbiddenKeys.Length; i++)
            {
                if (key == forbiddenKeys[i]) return true;
            }
            return false;
        }

        public static void delay(int time)
        {
            for (int i = 0; i < time; i++) ;
        }
        public static void StartMIV()
        {

            Console.WriteLine("Enter file's filename to open:");
            Console.WriteLine("If the specified file does not exist, it will be created.");
            Kernel.file = Console.ReadLine();
            try
            {
                if (File.Exists(@"0:\" + Kernel.file))
                {
                    Console.WriteLine("Found file!");
                    delay(1000);
                }
                else if (!File.Exists(@"0:\" + Kernel.file))
                {
                    Console.WriteLine("Creating file!");
                    File.Create(@"0:\" + Kernel.file);
                    delay(1000);

                }
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            String text = String.Empty;
            Console.WriteLine("Do you want to open " + Kernel.file + " content? (Yes/No)");
            var choice = Console.ReadLine().ToLower();
            if (choice == "yes" || choice == "y")
            {
                Console.WriteLine(File.Exists(@"0:\" + Kernel.file));
                text = miv(File.ReadAllText(@"0:\" + Kernel.file));
                Console.WriteLine(text);
            }
            else
            {
                Home();
            }

            Console.Clear();

            if (text != null)
            {
                File.WriteAllText(@"0:\" + Kernel.file, text);
                int l = 0;
                int wrd = 1;

                /* loop till end of string */
                while (l <= text.Length - 1)
                {
                    /* check whether the current character is white space or new line or tab character*/
                    if (text[l] == ' ' || text[l] == '\n' || text[l] == '\t')
                    {
                        wrd++;
                    }
                    l++;
                }

                int supernumber = wrd;
                int sentiment = 0;
                List<String> Good_Words = new List<String> { "amazing","awesome","beneficial","bright","brillant","clean","creative","cute","easy","essential","excellent","exceptional","fabulous"
,"fantastic","fine","free","fun","genius","glad","genuis","glad","good","great","happy","hearty","ideal","impressive","kind","like","love","lovely","nice","perfect"
,"plentiful","popular","powerful","powerful","pretty","quick","can recommend","refined","reliable","remarkable","rewarding","robust","satisfactory","satisfied"
,"simple","solid","special","stunning","super","superb","sweet","terrific","thanks","transformative","useful","vibrant","well","wellmade","what can i say"
,"wonderful","wondrous","worked","worked fine","worth","yup","works","soft","warm","unbeatable","unbelievable","what i need","use it","use this","best","strong"
,"improved","new","great","thick","better","accurate","unique","good","five stars","four stars","sound","helpful","expected","working","tight fit","handy","springy"
,"what can you say","5 stars","pleased","lightweight","affordable","acceptable","5 star","gorgeous", "glorious", "astounding", "elated", "exultant", "overjoyed","pleasant","peaceful" };
             
                List<String> Bad_Words = new List<String>{ "adequate","annoyance","annoying","average","avoid","awkward","bizarre","boring","zero","broken","bummer","busted","buzz","can't","cheap","cheaply"
,"crap","cumbersome","dirty","disappointed","digusted","displeased","does not","dull","flat","flimsy","garbage","iffy","joke","junk","noise","not bad","not good","ok"
,"stupid","toy","useless","vary","waste","you get what","yuck","yuk","pass","barely","sent it back","horrible","careful","issue","beware","break", "go build","poor","we get what"
,"lousy","clunky","died","issues","terrible","wtf","unfair","warning","weird", "not sturdy","different","sick","subsitutions","frustrating","worst","bare","bleh","stop working"
,"waste of money","shaky","low","glorified","prevent", "badly designed","dead","died","wiggly","defective","fluke","uninspiring","difficult","quit working","old","avoid","awful","problems"
,"alright"," 1 star"," 1 stars","2 stars","3 stars", "three stars", "two stars","complaint","miss wired","careful","weren't","didn't","wasn't","pain","tricky","decent","stiff","dont bother"
,"wobbly","didn't work","accident" };

                List<String> Good_Words1 = new List<String> { "aboard", "absorbed", "accept", "accepted", "accepting", "accepts", "achievable", "active", "adequate", "adopt", "adopts", "advanced", "agree", "agreed", "agreement", "agrees", "alive", "allow", "anticipation", "ardent", "attract", "attracted", "attracts", "authority", "backed", "backs", "big", "boost", "boosted", "boosting", "boosts", "bright", "brightness", "capable", "carefree", "certain", "clear", "cleared", "clearly", "clears", "comedy", "commit", "commits", "committed", "committing", "compelled", "convince", "convinced", "convinces", "cool", "cool", "cover-up", "curious", "decisive", "desire", "diamond", "dream", "dreams", "easy", "embrace", "engage", "engages", "engrossed", "ensure", "ensuring", "enterprising", "entitled", "expand", "expands", "exploration", "explorations", "extend", "extends", "faith", "fame", "feeling", "fit", "fitness", "forgive", "forgiving", "free", "fresh", "god", "grace", "grant", "granted", "granting", "grants", "greeted", "greeting", "greets", "growing", "guarantee", "haunting", "huge", "immune", "increase", "increased", "innovate", "innovates", "innovation", "intense", "interest", "interests", "intrigues", "invite", "inviting", "jesus", "jewel", "jewels", "join", "keen", "laugh", "laughed", "laughing", "laughs", "laughing", "launched", "legal", "legally", "lenient", "lighthearted", "made-matter", "matters", "meditative", "motivate", "motivation", "n", "natural", "pray", "praying", "prays", "prepared", "pretty", "promise", "promised", "promises", "promote", "promoted", "promotes", "promoting", "prospect", "prospects", "protect", "protected", "protects", "reach", "reached", "reaches", "reaching", "reassure", "reassured", "reassures", "relieve", "relieves", "restore", "restored", "restores", "restoring", "rightsafe", "safely", "safety", "salient", "share", "shared", "shares", "short-short-significance", "significant", "smart", "sobering", "solution", "solutions", "solve", "solved", "solves", "solving", "some kind", "son-of-a-spark", "spirit", "stimulate", "stimulated", "stimulates", "straight", "substantial", "substantially", "supporter", "supporters", "supporting", "trust", "unified", "united", "unmatched", "validate", "validated", "validates", "validating", "vested", "vision", "visioning", "visions", "vitamin", "want", "warm", "whimsical", "wish", "wishes", "wishing", "yeah", "yearning", "yes" };
                Console.WriteLine("Content has been saved to " + Kernel.file);

                List<String> Good_Words2 = new List<String> { "abilities","ability","absolve","absolved","absolves","absolving","accomplish","accomplished","accomplishes","acquit","acquits","acquitted","acquitting","advantage","advantages","adventure","adventures","adventurous","agog","agreeable","amaze","amazed","amazes","ambitious","appease","appeased","appeases","appeasing","applaud","applauded","applauding","applauds","applause","appreciate","appreciated","appreciates","appreciating","appreciation","approval","approved","approves","asset","assets","astonished","attracting","attraction","attractions","avid","backing","bargain","benefit","benefits","benefitted","benefitting","better","bless","blesses","blithe","bold","boldly","brave","brightest","brisk","buoyant","calm","calmed","calming","calms","care","careful","carefully","cares","chance","chances","cheer","cheered","cheerful","cheering","cheers","cherish","cherished","cherishes","cherishing","chic","clarifies","clarity","clean","cleaner","clever","comfort","comfortable","comforting","comforts","commend","commended","commitment","compassionate","competent","competitive","comprehensive","conciliate","conciliated","conciliates","conciliating","confidence","confident","congrats","congratulate","congratulation","congratulations","consent","consents","consolable","convivial","courage","courageous","courteous","courtesy","cover-coziness","creative","cute","daredevil","daring","dauntless","dear","debonair","dedicated","defender","defenders","desirable","desired","desirous","determined","eager","earnest","ease","effective","effectively","elegant","elegantly","empathetic","enchanted","encourage","encouraged","encouragement","encourages","endorse","endorsed","endorsement","endorses","energetic","enjoy","enjoying","enjoys","enlighten","enlightened","enlightening","enlightens","entertaining","entrusted","esteemed","ethical","exasperated","exclusive","exonerate","exonerated","exonerates","exonerating","fair","favor","favored","favorite","favorited","favorites","favors","fearless","fervent","fervid","festive","fine","flagship","focused","fond","fondness","fortunate","freedom","friendly","frisky","fulfill","fulfilled","fulfills","funky","futile","gain","gained","gaining","gains","generous","gift","glorious","glory","gratification","greetings","growth","ha","hail","hailed","hardier","hardy","healthy","heaven","help","helpful","helping","helps","hero","heroes","highlight","hilarious","honest","honor","honored","honoring","honour","honoured","honouring","hope","hopeful","hopefully","hopes","hoping","hug","hugs","humor","humorous","humour","humourous","immortal","importance","important","improve","improved","improvement","improves","improving","indestructible","infatuated","infatuation","influential","innovative","inquisitive","inspiration","inspirational","inspire","inspired","inspires","intact","integrity","intelligent","interested","interesting","intricate","invincible","invulnerable","irresistible","irresponsible","jaunty","jocular","joke","jokes","jolly","jovial","justice","justifiably","justified","kind","kinder","kiss","landmark","like","liked","likes","lively","loving","made-mature","meaningful","mercy","methodical","motivated","motivating","noble","novel","obsessed","oks","once-in-a-opportunities","opportunity","optimism","optimistic","outreach","pardon","pardoned","pardoning","pardons","passionate","peace","peaceful","peacefully","perfected","perfects","picturesque","playful","positive","positively","powerful","privileged","proactive","progress","prominent","proud","proudly","rapture","raptured","raptures","ratified","reassuring","recommend","recommended","recommends","redeemed","relaxed","reliant","relieved","relieving","relishing","remarkable","rescue","rescued","rescues","resolute","resolve","resolved","resolves","resolving","respected","responsible","responsive","restful","revered","revive","revives","reward","rewarded","rewarding","rewards","rich","robust","romance","satisfied","save","saved","secure","secured","secures","self-confident","self-serene","short-short-sincere","sincerely","sincerest","sincerity","slick","slicker","slickest","smarter","smartest","smile","smiled","smiles","smiling","solid","solidarity","somekind0son-of-a-sophisticated","spirited","sprightly","stable","stamina","steadfast","stimulating","stout","strength","strengthen","strengthened","strengthening","strengthens","strong","stronger","strongest","suave","success","sunshine","superior","support","supported","supportive","supports","survived","surviving","survivor","sweet","swift","swiftly","sympathetic","sympathy","tender","thank","thankful","thanks","thoughtful","tolerant","top","tops","tranquil","treasure","treasures","TRUE","trusted","unbiased","unequaled","unstoppable","untarnished","useful","usefulness","vindicate","vindicated","vindicates","vindicating","virtuous","warmth","wealthy","welcome","welcomed","welcomes","willingness","worth","worthy","yeees","youthful","zealous"
};
                List<String> Good_Words3 = new List<String> { "admire","admired","admires","admiring","adorable","adore","adored","adores","affection","affectionate","amuse","amused","amusement","amusements","astound","astounded","astounding","astoundingly","astounds","audacious","award","awarded","awards","beatific","beauties","beautiful","beautifully","beautify","beloved","best","blessing","bliss","blissful","blockbuster","breakthrough","captivated","celebrate","celebrated","celebrates","celebrating","charm","charming","cheery","classy","coolstuff","cover-dearly","delight","delighted","delighting","delights","devoted","elated","elation","enrapture","enthral","enthusiastic","euphoria","excellence","excellent","excite","excited","excitement","exciting","exhilarated","exhilarates","exhilarating","exultant","exultantly","faithful","fan","fascinate","fascinated","fascinates","fascinating","ftw","gallant","gallantly","gallantry","genial","glad","glamorous","glamourous","glee","gleeful","good","goodness","gracious","grand","grateful","great","greater","greatest","haha","hahaha","hahahah","happiness","happy","heartfelt","heroic","humerous","impress","impressed","impresses","impressive","inspiring","joy","joyful","joyfully","joyous","jubilant","kudos","lawl","lol","lovable","love","loved","lovelies","lovely","loyal","loyalty","luck","luckily","lucky","made-marvel","marvelous","marvels","medal","merry","mirth","mirthful","mirthfully","n00nice","ominous","once in a lifetime","paradise","perfect","perfectly","pleasant","pleased","pleasure","popular","praise","praised","praises","praising","prosperous","rightdirection","rigorous","rigorously","scoop","sexy","soothe","soothed","soothing","sparkle","sparkles","sparkling","splendid","successful","super","vibrant","vigilant","visionary","vitality","vivacious","wealth","winwin","won","woo","woohoo","worshiped","yummy"};
                List<String> Good_Words4 = new List<String> { "amazing","awesome","brilliant","ecstatic","euphoric","exuberant","fabulous","fantastic","fun","funnier","funny","godsend","heavenly","lifesaver","lmao","lmfao","made-masterpiece","masterpieces","miracle","overjoyed","rapturous","rejoice","rejoiced","rejoices","rejoicing","rofl","roflcopter","roflmao","rofl","rotf","lmfao","rotflol","stunning","terrific","triumph","triumphant","win","winner","winning","wins","wonderful","wooo","woow","wow","wowow","wowww"
};
                List<String> Good_Words5 = new List<String> { "breathtaking","hurrah","outstanding","superb","thrilled"
};
                List<String> Bad_Words1 = new List<String> { "absentee","absentees","admit","admits","admitted","affected","afflicted","affronted","alas","alert","ambivalent","anti","apologise","apologised","apologises","apologising","apologize","apologized","apologizes","apologizing","apology","attack","attacked","attacking","attacks","avert","averted","averts","avoid","avoided","avoids","await","awaited","awaits","axe","axed","banish","battle","battles","beating","bias","blind","block","blocked","blocking","blocks","bomb","broke","broken","can'cancel","cancelled","cancelling","cancels","cancer","cautious","challenge","chilling","clouded","collide","collides","colliding","combat","combats","contagious","contend","contender","contending","corpse","cover-cramp","crush","crushes","crushing","cry","curse","cut","cuts","cutting","darkness","deafening","defer","deferring","defiant","delay","delayed","demand","demanded","demanding","demands","demonstration","detached","difficult","dilemma","disabling","disappear","disappeared","disappears","discard","discarded","discarding","discards","discounted","disguise","disguised","disguises","disguising","dizzy","doubt","doubted","doubtful","doubting","doubts","drag","dragged","drags","drop","dump","dumps","emptiness","empty","envies","envy","envying","escape","escapes","escaping","eviction","exclude","exclusion","excuse","exempt","expose","exposed","exposes","exposing","falling","farce","fight","flees","forced","forget","forgotten","frantic","frowning","funeral","funerals","ghost","gloom","gray","grey","gun","hacked","hard","haunt","haunts","hid","hide","hides","hiding","ignore","ignores","immobilized","impose","imposed","imposes","imposing","inhibit","ironic","irony","irrational","irreversible","isolated","jumpy","lag","lazy","leak","leaked","leave","limitation","limited","limits","litigation","longing","loom","loomed","looming","looms","lowest","lurk","lurking","lurks","made-up","mandatory","manipulated","manipulating","manipulation","mischief","mischiefs","misread","moody","mope","moping","myth","n00nerves","no","noisy","numb","offline","once-in-a-overload","overlooked","overweight","oxymoron","paradox","parley","passive","passively","pay","pensive","pileup","pitied","postpone","postponed","postpones","postponing","poverty","pressure","pretend","pretending","pretends","prevent","prevented","preventing","prevents","prosecute","prosecutes","prosecution","provoke","provoked","provokes","provoking","pushy","questioned","questioning","rainy","reject","rejected","rejecting","rejects","relentless","repulse","resign","resigned","resigning","resigns","retained","retreat","rig","rigged","sappy","seduced","self-self-shoot","short-short-shy","silencing","silly","sneaky","solemn","son-of-a-sore","sorry","squelched","stifled","stop","stopped","stopping","stops","strange","strangely","strike","strikes","struck","suspect","suspected","suspecting","suspects","suspend","suspended","tension","trap","unbelievable","unbelieving","uncertain","unclear","unconfirmed","unconvinced","uncredited","undecided","underestimate","underestimated","underestimates","underestimating","unequal","unsettled","unsure","urgent","verdict","verdicts","vociferous","waste","wavering","widowed","worn"
};
                List<String> Bad_Words2 = new List<String> { "abandon","abandoned","abandons","abducted","abduction","abductions","accident","accidental","accidentally","accidents","accusation","accusations","accuse","accused","accuses","accusing","ache","aching","admonish","admonished","afraid","aggravate","aggravated","aggravates","aggravating","aggression","aggressions","aggressive","aghast","alarm","alarmed","alarmist","alarmists","alienation","allergic","alone","animosity","annoy","annoyance","annoyed","annoying","annoys","antagonistic","anxiety","anxious","apocalyptic","appalled","appalling","apprehensive","arrest","arrests","arrogant","ashame","ashamed","awkward","bailout","bamboozle","bamboozled","bamboozles","ban","banned","barrier","beaten","belittle","belittled","bereave","bereaved","bereaves","bereaving","biased","bitter","bitterly","bizarre","blah","blame","blamed","blames","blaming","blurry","boastful","bore","bored","bother","bothered","bothers","bothersome","boycott","boycotted","boycotting","boycotts","brooding","bullied","bully","bullying","bummer","burden","burdened","burdening","burdens","can'careless","cashingin","casualty","censor","censored","censors","chagrin","chagrined","chaos","chaotic","charges","cheerless","childish","choke","choked","chokes","choking","clash","clueless","cocky","coerced","collapse","collapsed","collapses","collapsing","collision","collisions","complacent","complain","complained","complains","condemn","condemnation","condemned","condemns","conflict","conflicting","conflictive","conflicts","confuse","confused","confusing","constrained","contagion","contagions","contempt","contemptuous","contemptuously","contentious","contestable","controversial","controversially","cornered","costly","cover-coward","cowardly","crash","crazier","craziest","crazy","crestfallen","cried","cries","critic","criticism","criticize","criticized","criticizes","criticizing","critics","crushed","crying","cynic","cynical","cynicism","danger","darkest","deadlock","death","debt","defeated","defenseless","deficit","degrade","degraded","degrades","dehumanize","dehumanized","dehumanizes","dehumanizing","deject","dejected","dejecting","dejects","demoralized","denied","denier","deniers","denies","denounce","denounces","deny","denying","depressed","depressing","derail","derailed","derails","deride","derided","derides","deriding","derision","detain","detained","detention","devastate","devastated","devastating","diffident","dirt","dirtier","dirtiest","dirty","disadvantage","disadvantaged","disappoint","disappointed","disappointing","disappointment","disappointments","disappoints","disaster","disasters","disbelieve","disconsolate","disconsolation","discontented","discord","discouraged","discredited","disdain","disgrace","disgraced","disheartened","dishonest","disillusioned","disinclined","disjointed","dislike","dismal","dismayed","disorder","disorganized","disoriented","disparage","disparaged","disparages","disparaging","displeased","dispute","disputed","disputes","disputing","disqualified","disquiet","disregard","disregarded","disregarding","disregards","disrespect","disrespected","disruption","disruptions","disruptive","dissatisfied","distort","distorted","distorting","distorts","distract","distracted","distraction","distracts","distress","distressed","distresses","distressing","disturb","disturbed","disturbing","disturbs","dithering","dodging","dodgy","dolorous","dontlike","doom","doomed","downcast","downhearted","downside","drained","dread","dreaded","dreading","dreary","droopy","drown","drowned","drowns","drunk","dubious","dud","dull","dumped","dupe","duped","dysfunction","eerie","eery","embarrass","embarrassed","embarrasses","embarrassing","embarrassment","embittered","emergency","enemies","enemy","ennui","enrage","enraged","enrages","enraging","enslave","enslaved","enslaves","envious","erroneous","error","errors","exaggerate","exaggerated","exaggerates","exaggerating","excluded","exhausted","expel","expelled","expelling","expels","exploit","exploited","exploiting","exploits","fad","fail","failed","failing","fails","failure","failures","fainthearted","fallen","fascist","fascists","fatigue","fatigued","fatigues","fatiguing","fear","fearful","fearing","fearsome","feeble","fidgety","fire","fired","firing","flop","flops","flu","flustered","fool","foolish","fools","foreclosure","foreclosures","forgetful","fright","frightened","frikin","frustrate","frustrated","frustrates","frustrating","frustration","fuming","gag","gagged","giddy","gloomy","glum","grave","greedy","grief","grieved","gross","gullibility","gullible","hapless","haplessness","hardship","harm","harmed","harmful","harming","harms","harried","harsh","harsher","harshest","haunted","havoc","heavyhearted","helpless","hesitant","hesitate","hindrance","hoax","homesick","hooligan","hooliganism","hooligans","hopeless","hopelessness","hostile","huckster","hunger","hurt","hurting","hurts","hypocritical","ignorance","ignorant","ignored","ill","illiteracy","illness","illnesses","impatient","imperfect","impotent","imprisoned","inability","inaction","inadequate","incapable","incapacitated","incensed","incompetence","incompetent","inconsiderate","inconvenience","inconvenient","indecisive","indifference","indifferent","indignant","indignation","indoctrinate","indoctrinated","indoctrinates","indoctrinating","ineffective","ineffectively","infected","inferior","inflamed","infringement","infuriate","infuriated","infuriates","infuriating","injured","injury","injustice","inquisition","insane","insanity","insecure","insensitive","insensitivity","insignificant","insipid","insult","insulted","insulting","insults","interrogated","interrupt","interrupted","interrupting","interruption","interrupts","intimidate","intimidated","intimidates","intimidating","intimidation","irresolute","itchy","jailed","jealous","jeopardy","joyless","lack","lackadaisical","lagged","lagging","lags","lame","lawsuit","lawsuits","lethargic","lethargy","libelous","lied","litigious","livid","lobby","lobbying","lonely","lonesome","lugubrious","made-meaningless","melancholy","menace","menaced","mess","messed","messingup","mindless","misbehave","misbehaved","misbehaves","misbehaving","misery","misgiving","misinformation","misinformed","misinterpreted","misreporting","misrepresentation","miss","missed","missing","mistake","mistaken","mistakes","mistaking","misunderstand","misunderstanding","misunderstands","misunderstood","moan","moaned","moaning","moans","mock","mocked","mocking","mocks","mongering","monopolize","monopolized","monopolizes","monopolizing","mourn","mourned","mournful","mourning","mourns","mumpish","murder","murderer","murders","n00b","naive","naïve","needy","negative","negativity","neglect","neglected","neglecting","neglects","nervous","nervously","nonsense","noob","nosey","notgood","notorious","obliterate","obliterated","obscene","obsolete","obstacle","obstacles","obstinate","odd","offend","offended","offender","offending","offends","once-in-a-oppressed","oppressive","optionless","outcry","outmaneuvered","overreact","overreacted","overreaction","overreacts","oversell","overselling","oversells","oversimplification","oversimplified","oversimplifies","oversimplify","overstatement","overstatements","pain","pained","pathetic","penalty","peril","perpetrator","perpetrators","perplexed","persecute","persecuted","persecutes","persecuting","perturbed","pesky","pessimism","pessimistic","petrified","phobic","pique","piqued","piteous","pity","poised","poison","poisoned","poisons","pollute","polluted","polluter","polluters","pollutes","poor","poorer","poorest","possessive","powerless","prblm","prblms","pressured","prison","prisoner","prisoners","problem","problems","profiteer","propaganda","prosecuted","protest","protesters","protesting","protests","punish","punished","punishes","punitive","puzzled","quaking","questionable","rage","rageful","rash","rebellion","recession","reckless","refuse","refused","refusing","regret","regretful","regrets","regretted","regretting","remorse","repulsed","resentful","restless","restrict","restricted","restricting","restriction","restricts","retard","retarded","revenge","revengeful","riot","riots","risk","risks","rob","robber","robed","robing","robs","ruin","ruined","ruining","ruins","sabotage","sad","sadden","saddened","sadly","sarcastic","scam","scams","scapegoat","scapegoats","scare","scared","scary","sceptical","scold","scorn","scornful","scream","screamed","screaming","screams","screwed","sedition","seditious","self-self-deluded","sentence","sentenced","sentences","sentencing","severe","shaky","shame","shamed","shameful","shattered","shock","shocked","shocking","shocks","short-sighted","short-sightedness","shortage","shortages","sick","sigh","singleminded","skeptic","skeptical","skepticism","skeptics","slam","slash","slashed","slashes","slashing","sleeplessness","sluggish","smear","smog","snub","snubbed","snubbing","snubs","somber","somekind0son-of-a-sorrow","sorrowful","spam","spamming","speculative","spiritless","spiteful","stab","stabbed","stabs","stall","stalled","stalling","stampede","startled","starve","starved","starves","starving","steal","steals","stereotype","stereotyped","stingy","stolen","strangled","stressed","stressor","stressors","stricken","strikers","struggle","struggled","struggles","struggling","stubborn","stuck","stunned","stupid","stupidly","subversive","suffer","suffering","suffers","suicidal","suicide","suing","sulking","sulky","sullen","suspicious","swear","swearing","swears","tard","tears","tense","thorny","thoughtless","threat","threaten","threatened","threatening","threatens","threats","thwart","thwarted","thwarting","thwarts","timid","timorous","tired","tits","toothless","torn","totalitarian","totalitarianism","tout","touted","touting","touts","tragedy","tragic","trapped","travesty","trembling","tremulous","tricked","trickery","trouble","troubled","troubles","tumor","unacceptable","unappreciated","unapproved","unaware","uncomfortable","unconcerned","undermine","undermined","undermines","undermining","undeserving","undesirable","uneasy","unemployment","unethical","unfair","unfocused","unfulfilled","unhappy","unhealthy","unimpressed","unintelligent","unjust","unlovable","unloved","unmotivated","unprofessional","unresearched","unsatisfied","unsecured","unsophisticated","unstable","unsupported","unwanted","unworthy","upset","upsets","upsetting","uptight","useless","uselessness","vague","vexation","vexing","vicious","violate","violated","violates","violating","virulent","vulnerability","vulnerable","walkout","walkouts","war","warfare","warn","warned","warns","wasted","wasting","weak","weakness","weary","weep","weeping","weird","wicked","woebegone","worthless","wreck","wrong","wronged","yucky","zealot","zealots"
};
                List<String> Bad_Words3 = new List<String> {"abhor","abhorred","abhorrent","abhors","abuse","abused","abuses","abusive","acrimonious","agonise","agonised","agonises","agonising","agonize","agonized","agonizes","agonizing","anger","angers","angry","anguish","anguished","apathetic","apathy","apeshit","arrested","assassination","assassinations","awful","bad","badass","badly","bankrupt","bankster","betray","betrayal","betrayed","betraying","betrays","bloody","boring","brainwashing","bribe","can'tstand","catastrophe","charged","charmless","chastise","chastised","chastises","chastising","cheat","cheated","cheater","cheaters","cheats","colluding","conspiracy","cover-up","crap","crime","criminal","criminals","crisis","cruel","cruelty","damage","damages","dead","deceit","deceitful","deceive","deceived","deceives","deceiving","deception","defect","defects","despair","despairing","despairs","desperate","desperately","despondent","destroy","destroyed","destroying","destroys","destruction","destructive","die","died","dipshit","dire","direful","disastrous","disgust","disgusted","disgusting","distrust","distrustful","doesnotwork","douche","douchebag","dreadful","dumb","dumbass","evil","fag","faggot","faggots","fake","fakes","faking","falsified","falsify","fatalities","fatality","fedup","felonies","felony","fiasco","frenzy","frightening","fud","furious","goddamn","greed","greenwash","greenwashing","greenwash","greenwasher","greenwashers","greenwashing","guilt","guilty","hate","hated","haters","hates","hating","heartbreaking","heartbroken","horrendous","horrible","horrific","horrified","humiliated","humiliation","hysteria","hysterical","hysterics","idiot","idiotic","illegal","imbecile","irate","irritate","irritated","irritating","jerk","kill","killed","killing","kills","liar","liars","loathe","loathed","loathes","loathing","loose","looses","loser","losing","loss","lost","lunatic","lunatics","mad","maddening","made-madly","madness","mediocrity","miserable","misleading","moron","murdering","murderous","n00nasty","nofun","notworking","nuts","obnoxious","once-in-a-outrage","outraged","panic","panicked","panics","perjury","pissing","pseudoscience","racism","racist","racists","rant","ranter","ranters","rants","ridiculous","scandal","scandalous","scandals","screwedup","self-self-selfish","selfishness","shitty","short-short-sinful","slavery","son-of-a-spammer","spammers","suck","sucks","swindle","swindles","swindling","terrible","terribly","terrified","terror","terrorize","terrorized","terrorizes","trauma","traumatic","treason","treasonous","ugly","victim","victimize","victimized","victimizes","victimizing","victims","vile","violence","violent","vitriolic","wanker","warning","warnings","whitewash","withdrawal","woeful","worried","worry","worrying","worse","worsen","worsened","worsening","worsens","worst","wrathful"
 };
                List<String> Bad_Words4 = new List<String> { "ass","assfucking","asshole","bullshit","catastrophic","damn","damned","damnit","dick","dickhead","fraud","frauds","fraudster","fraudsters","fraudulence","fraudulent","fuck","fucked","fucker","fuckers","fuckface","fuckhead","fucking","fucktard","fuked","fuking","hell","jackass","jackasses","piss","pissed","rape","rapist","scumbag","shit","shithead","short-short-shrew","torture","tortured","tortures","torturing","whore","wtf"
};
                List<String> Bad_Words5 = new List<String>{ "Bastard","bastards","bitch","bitches","cock","cocksucker","cocksuckers","cunt","motherfucker","motherfucking","niggas","nigger","prick","slut","son of a bitch","twat"
};
                string[] words = text.Split(' ', '\n', '\t');
                int supercount = 0;
                Console.WriteLine("\n---------DEBUG START:---------");

                for (int i = 0; i < supernumber; i++)
                {
                    for (int j = 0; j < 110; j++)
                    {
                        
                            if (Good_Words1[j] == words[i])
                            {
                                Console.WriteLine(words[i] + ",");
                                sentiment = sentiment + 1;
                                supercount += 1;
                            }


                            if (Good_Words2[j] == words[i])
                            {
                                Console.WriteLine(words[i] + ",");
                                sentiment = sentiment + 2;
                                supercount += 1;
                            }

                            else if (Good_Words3[j] == words[i])
                            {
                                Console.WriteLine(words[i] + ",");
                                sentiment = sentiment + 3;
                                supercount += 1;
                            }
                            else if (Good_Words4[j] == words[i])
                            {
                                Console.WriteLine(words[i] + ",");
                                sentiment = sentiment + 4;
                                supercount += 1;
                            }
                            else if (Good_Words5[j] == words[i])
                            {
                                Console.WriteLine(words[i] + ",");
                                sentiment = sentiment + 5;
                                supercount += 1;
                            } 
                            if (Good_Words[j] == words[i])
                            {
                                Console.WriteLine(words[i] + ",");
                                sentiment = sentiment + 1;
                                supercount += 1;
                            }


                            else if (Bad_Words1[j] == words[i])
                            {
                                Console.WriteLine(words[i] + ",");

                                sentiment = sentiment - 1;
                                supercount += 1;
                            }
                            else if (Bad_Words2[j] == words[i])
                            {
                                Console.WriteLine(words[i] + ",");

                                sentiment = sentiment - 2;
                                supercount += 1;
                            }
                            else if (Bad_Words3[j] == words[i])
                            {
                                Console.WriteLine(words[i] + ",");

                                sentiment = sentiment - 3;
                                supercount += 1;
                            }
                            else if (Bad_Words4[j] == words[i])
                            {
                                Console.WriteLine(words[i] + ",");

                                sentiment = sentiment - 4;
                                supercount += 1;
                            }
                            else if (Bad_Words5[j] == words[i])
                            {
                                Console.WriteLine(words[i] + ",");

                                sentiment = sentiment - 5;
                                supercount += 1;
                            }
                             if (Bad_Words[j] == words[i])
                            {
                                Console.WriteLine(words[i] + ",");

                                sentiment = sentiment - 1;
                                supercount += 1;
                            }
                        
                        
                    }
                     

                }
                Console.WriteLine("\n---------DEBUG END:---------");
                Console.WriteLine("sentiment ==" + sentiment);
                Console.WriteLine("supercount==" + supercount);
                if (supercount / 2 >= sentiment)
                {
                    Console.WriteLine("TAKE CARE");
                }
                else
                {
                    Console.WriteLine("YOU ARE DOING GREAT");
                }


            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
