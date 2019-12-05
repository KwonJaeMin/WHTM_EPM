using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MainLibrary.Utility
{
    public class Code128
    {
        /// <summary>
        /// Summary description for Code128Rendering.
        /// </summary>
        public static class Code128Rendering
        {

            #region Code patterns

            // in principle these rows should each have 6 elements
            // however, the last one -- STOP -- has 7. The cost of the
            // extra integers is trivial, and this lets the code flow
            // much more elegantly
            private static readonly int[,] cPatterns = 
                     {
                        {2,1,2,2,2,2,0,0},  // 0
                        {2,2,2,1,2,2,0,0},  // 1
                        {2,2,2,2,2,1,0,0},  // 2
                        {1,2,1,2,2,3,0,0},  // 3
                        {1,2,1,3,2,2,0,0},  // 4
                        {1,3,1,2,2,2,0,0},  // 5
                        {1,2,2,2,1,3,0,0},  // 6
                        {1,2,2,3,1,2,0,0},  // 7
                        {1,3,2,2,1,2,0,0},  // 8
                        {2,2,1,2,1,3,0,0},  // 9
                        {2,2,1,3,1,2,0,0},  // 10
                        {2,3,1,2,1,2,0,0},  // 11
                        {1,1,2,2,3,2,0,0},  // 12
                        {1,2,2,1,3,2,0,0},  // 13
                        {1,2,2,2,3,1,0,0},  // 14
                        {1,1,3,2,2,2,0,0},  // 15
                        {1,2,3,1,2,2,0,0},  // 16
                        {1,2,3,2,2,1,0,0},  // 17
                        {2,2,3,2,1,1,0,0},  // 18
                        {2,2,1,1,3,2,0,0},  // 19
                        {2,2,1,2,3,1,0,0},  // 20
                        {2,1,3,2,1,2,0,0},  // 21
                        {2,2,3,1,1,2,0,0},  // 22
                        {3,1,2,1,3,1,0,0},  // 23
                        {3,1,1,2,2,2,0,0},  // 24
                        {3,2,1,1,2,2,0,0},  // 25
                        {3,2,1,2,2,1,0,0},  // 26
                        {3,1,2,2,1,2,0,0},  // 27
                        {3,2,2,1,1,2,0,0},  // 28
                        {3,2,2,2,1,1,0,0},  // 29
                        {2,1,2,1,2,3,0,0},  // 30
                        {2,1,2,3,2,1,0,0},  // 31
                        {2,3,2,1,2,1,0,0},  // 32
                        {1,1,1,3,2,3,0,0},  // 33
                        {1,3,1,1,2,3,0,0},  // 34
                        {1,3,1,3,2,1,0,0},  // 35
                        {1,1,2,3,1,3,0,0},  // 36
                        {1,3,2,1,1,3,0,0},  // 37
                        {1,3,2,3,1,1,0,0},  // 38
                        {2,1,1,3,1,3,0,0},  // 39
                        {2,3,1,1,1,3,0,0},  // 40
                        {2,3,1,3,1,1,0,0},  // 41
                        {1,1,2,1,3,3,0,0},  // 42
                        {1,1,2,3,3,1,0,0},  // 43
                        {1,3,2,1,3,1,0,0},  // 44
                        {1,1,3,1,2,3,0,0},  // 45
                        {1,1,3,3,2,1,0,0},  // 46
                        {1,3,3,1,2,1,0,0},  // 47
                        {3,1,3,1,2,1,0,0},  // 48
                        {2,1,1,3,3,1,0,0},  // 49
                        {2,3,1,1,3,1,0,0},  // 50
                        {2,1,3,1,1,3,0,0},  // 51
                        {2,1,3,3,1,1,0,0},  // 52
                        {2,1,3,1,3,1,0,0},  // 53
                        {3,1,1,1,2,3,0,0},  // 54
                        {3,1,1,3,2,1,0,0},  // 55
                        {3,3,1,1,2,1,0,0},  // 56
                        {3,1,2,1,1,3,0,0},  // 57
                        {3,1,2,3,1,1,0,0},  // 58
                        {3,3,2,1,1,1,0,0},  // 59
                        {3,1,4,1,1,1,0,0},  // 60
                        {2,2,1,4,1,1,0,0},  // 61
                        {4,3,1,1,1,1,0,0},  // 62
                        {1,1,1,2,2,4,0,0},  // 63
                        {1,1,1,4,2,2,0,0},  // 64
                        {1,2,1,1,2,4,0,0},  // 65
                        {1,2,1,4,2,1,0,0},  // 66
                        {1,4,1,1,2,2,0,0},  // 67
                        {1,4,1,2,2,1,0,0},  // 68
                        {1,1,2,2,1,4,0,0},  // 69
                        {1,1,2,4,1,2,0,0},  // 70
                        {1,2,2,1,1,4,0,0},  // 71
                        {1,2,2,4,1,1,0,0},  // 72
                        {1,4,2,1,1,2,0,0},  // 73
                        {1,4,2,2,1,1,0,0},  // 74
                        {2,4,1,2,1,1,0,0},  // 75
                        {2,2,1,1,1,4,0,0},  // 76
                        {4,1,3,1,1,1,0,0},  // 77
                        {2,4,1,1,1,2,0,0},  // 78
                        {1,3,4,1,1,1,0,0},  // 79
                        {1,1,1,2,4,2,0,0},  // 80
                        {1,2,1,1,4,2,0,0},  // 81
                        {1,2,1,2,4,1,0,0},  // 82
                        {1,1,4,2,1,2,0,0},  // 83
                        {1,2,4,1,1,2,0,0},  // 84
                        {1,2,4,2,1,1,0,0},  // 85
                        {4,1,1,2,1,2,0,0},  // 86
                        {4,2,1,1,1,2,0,0},  // 87
                        {4,2,1,2,1,1,0,0},  // 88
                        {2,1,2,1,4,1,0,0},  // 89
                        {2,1,4,1,2,1,0,0},  // 90
                        {4,1,2,1,2,1,0,0},  // 91
                        {1,1,1,1,4,3,0,0},  // 92
                        {1,1,1,3,4,1,0,0},  // 93
                        {1,3,1,1,4,1,0,0},  // 94
                        {1,1,4,1,1,3,0,0},  // 95
                        {1,1,4,3,1,1,0,0},  // 96
                        {4,1,1,1,1,3,0,0},  // 97
                        {4,1,1,3,1,1,0,0},  // 98
                        {1,1,3,1,4,1,0,0},  // 99
                        {1,1,4,1,3,1,0,0},  // 100
                        {3,1,1,1,4,1,0,0},  // 101
                        {4,1,1,1,3,1,0,0},  // 102
                        {2,1,1,4,1,2,0,0},  // 103
                        {2,1,1,2,1,4,0,0},  // 104
                        {2,1,1,2,3,2,0,0},  // 105
                        {2,3,3,1,1,1,2,0}   // 106
                     };

            #endregion Code patterns

            private const int cQuietWidth = 10;

            /// <summary>
            /// Make an image of a Code128 barcode for a given string
            /// </summary>
            /// <param name="InputData">Message to be encoded</param>
            /// <param name="BarWeight">Base thickness for bar width (1 or 2 works well)</param>
            /// <param name="AddQuietZone">Add required horiz margins (use if output is tight)</param>
            /// <returns>An Image of the Code128 barcode representing the message</returns>
            public static Image MakeBarcodeImage(string InputData, int BarWeight, bool AddQuietZone)
            {
                // get the Code128 codes to represent the message
                Code128Content content = new Code128Content(InputData);
                int[] codes = content.Codes;

                int width, height;
                width = ((codes.Length - 3) * 11 + 35) * BarWeight;
                height = Convert.ToInt32(System.Math.Ceiling(Convert.ToSingle(width) * .15F));

                if (AddQuietZone)
                {
                    width += 2 * cQuietWidth * BarWeight;  // on both sides
                }

                // get surface to draw on
                Image myimg = new System.Drawing.Bitmap(width, height);
                using (Graphics gr = Graphics.FromImage(myimg))
                {

                    // set to white so we don't have to fill the spaces with white
                    gr.FillRectangle(System.Drawing.Brushes.White, 0, 0, width, height);

                    // skip quiet zone
                    int cursor = AddQuietZone ? cQuietWidth * BarWeight : 0;

                    for (int codeidx = 0; codeidx < codes.Length; codeidx++)
                    {
                        int code = codes[codeidx];

                        // take the bars two at a time: a black and a white
                        for (int bar = 0; bar < 8; bar += 2)
                        {
                            int barwidth = cPatterns[code, bar] * BarWeight;
                            int spcwidth = cPatterns[code, bar + 1] * BarWeight;

                            // if width is zero, don't try to draw it
                            if (barwidth > 0)
                            {
                                gr.FillRectangle(System.Drawing.Brushes.Black, cursor, 0, barwidth, height);
                            }

                            // note that we never need to draw the space, since we 
                            // initialized the graphics to all white

                            // advance cursor beyond this pair
                            cursor += (barwidth + spcwidth);
                        }
                    }
                }

                return myimg;

            }

        }

        public enum CodeSet
        {
            CodeA
            , CodeB
            // ,CodeC   // not supported
        }

        /// <summary>
        /// Represent the set of code values to be output into barcode form
        /// </summary>
        public class Code128Content
        {
            private int[] mCodeList;

            /// <summary>
            /// Create content based on a string of ASCII data
            /// </summary>
            /// <param name="AsciiData">the string that should be represented</param>
            public Code128Content(string AsciiData)
            {
                mCodeList = StringToCode128(AsciiData);
            }

            /// <summary>
            /// Provides the Code128 code values representing the object's string
            /// </summary>
            public int[] Codes
            {
                get
                {
                    return mCodeList;
                }
            }

            /// <summary>
            /// Transform the string into integers representing the Code128 codes
            /// necessary to represent it
            /// </summary>
            /// <param name="AsciiData">String to be encoded</param>
            /// <returns>Code128 representation</returns>
            private int[] StringToCode128(string AsciiData)
            {
                // turn the string into ascii byte data
                byte[] asciiBytes = Encoding.ASCII.GetBytes(AsciiData);

                // decide which codeset to start with
                Code128Code.CodeSetAllowed csa1 = asciiBytes.Length > 0 ? Code128Code.CodesetAllowedForChar(asciiBytes[0]) : Code128Code.CodeSetAllowed.CodeAorB;
                Code128Code.CodeSetAllowed csa2 = asciiBytes.Length > 0 ? Code128Code.CodesetAllowedForChar(asciiBytes[1]) : Code128Code.CodeSetAllowed.CodeAorB;
                CodeSet currcs = GetBestStartSet(csa1, csa2);

                // set up the beginning of the barcode
                System.Collections.ArrayList codes = new System.Collections.ArrayList(asciiBytes.Length + 3); // assume no codeset changes, account for start, checksum, and stop
                codes.Add(Code128Code.StartCodeForCodeSet(currcs));

                // add the codes for each character in the string
                for (int i = 0; i < asciiBytes.Length; i++)
                {
                    int thischar = asciiBytes[i];
                    int nextchar = asciiBytes.Length > (i + 1) ? asciiBytes[i + 1] : -1;

                    codes.AddRange(Code128Code.CodesForChar(thischar, nextchar, ref currcs));
                }

                // calculate the check digit
                int checksum = (int)(codes[0]);
                for (int i = 1; i < codes.Count; i++)
                {
                    checksum += i * (int)(codes[i]);
                }
                codes.Add(checksum % 103);

                codes.Add(Code128Code.StopCode());

                int[] result = codes.ToArray(typeof(int)) as int[];
                return result;
            }

            /// <summary>
            /// Determines the best starting code set based on the the first two 
            /// characters of the string to be encoded
            /// </summary>
            /// <param name="csa1">First character of input string</param>
            /// <param name="csa2">Second character of input string</param>
            /// <returns>The codeset determined to be best to start with</returns>
            private CodeSet GetBestStartSet(Code128Code.CodeSetAllowed csa1, Code128Code.CodeSetAllowed csa2)
            {
                int vote = 0;

                vote += (csa1 == Code128Code.CodeSetAllowed.CodeA) ? 1 : 0;
                vote += (csa1 == Code128Code.CodeSetAllowed.CodeB) ? -1 : 0;
                vote += (csa2 == Code128Code.CodeSetAllowed.CodeA) ? 1 : 0;
                vote += (csa2 == Code128Code.CodeSetAllowed.CodeB) ? -1 : 0;

                return (vote > 0) ? CodeSet.CodeA : CodeSet.CodeB;   // ties go to codeB due to my own prejudices
            }
        }

        /// <summary>
        /// Static tools for determining codes for individual characters in the content
        /// </summary>
        public static class Code128Code
        {
            #region Constants

            private const int cSHIFT = 98;
            private const int cCODEA = 101;
            private const int cCODEB = 100;

            private const int cSTARTA = 103;
            private const int cSTARTB = 104;
            private const int cSTOP = 106;

            #endregion

            /// <summary>
            /// Get the Code128 code value(s) to represent an ASCII character, with 
            /// optional look-ahead for length optimization
            /// </summary>
            /// <param name="CharAscii">The ASCII value of the character to translate</param>
            /// <param name="LookAheadAscii">The next character in sequence (or -1 if none)</param>
            /// <param name="CurrCodeSet">The current codeset, that the returned codes need to follow;
            /// if the returned codes change that, then this value will be changed to reflect it</param>
            /// <returns>An array of integers representing the codes that need to be output to produce the 
            /// given character</returns>
            public static int[] CodesForChar(int CharAscii, int LookAheadAscii, ref CodeSet CurrCodeSet)
            {
                int[] result;
                int shifter = -1;

                if (!CharCompatibleWithCodeset(CharAscii, CurrCodeSet))
                {
                    // if we have a lookahead character AND if the next character is ALSO not compatible
                    if ((LookAheadAscii != -1) && !CharCompatibleWithCodeset(LookAheadAscii, CurrCodeSet))
                    {
                        // we need to switch code sets
                        switch (CurrCodeSet)
                        {
                            case CodeSet.CodeA:
                                shifter = cCODEB;
                                CurrCodeSet = CodeSet.CodeB;
                                break;
                            case CodeSet.CodeB:
                                shifter = cCODEA;
                                CurrCodeSet = CodeSet.CodeA;
                                break;
                        }
                    }
                    else
                    {
                        // no need to switch code sets, a temporary SHIFT will suffice
                        shifter = cSHIFT;
                    }
                }

                if (shifter != -1)
                {
                    result = new int[2];
                    result[0] = shifter;
                    result[1] = CodeValueForChar(CharAscii);
                }
                else
                {
                    result = new int[1];
                    result[0] = CodeValueForChar(CharAscii);
                }

                return result;
            }

            /// <summary>
            /// Tells us which codesets a given character value is allowed in
            /// </summary>
            /// <param name="CharAscii">ASCII value of character to look at</param>
            /// <returns>Which codeset(s) can be used to represent this character</returns>
            public static CodeSetAllowed CodesetAllowedForChar(int CharAscii)
            {
                if (CharAscii >= 32 && CharAscii <= 95)
                {
                    return CodeSetAllowed.CodeAorB;
                }
                else
                {
                    return (CharAscii < 32) ? CodeSetAllowed.CodeA : CodeSetAllowed.CodeB;
                }
            }

            /// <summary>
            /// Determine if a character can be represented in a given codeset
            /// </summary>
            /// <param name="CharAscii">character to check for</param>
            /// <param name="currcs">codeset context to test</param>
            /// <returns>true if the codeset contains a representation for the ASCII character</returns>
            public static bool CharCompatibleWithCodeset(int CharAscii, CodeSet currcs)
            {
                CodeSetAllowed csa = CodesetAllowedForChar(CharAscii);
                return csa == CodeSetAllowed.CodeAorB
                         || (csa == CodeSetAllowed.CodeA && currcs == CodeSet.CodeA)
                         || (csa == CodeSetAllowed.CodeB && currcs == CodeSet.CodeB);
            }

            /// <summary>
            /// Gets the integer code128 code value for a character (assuming the appropriate code set)
            /// </summary>
            /// <param name="CharAscii">character to convert</param>
            /// <returns>code128 symbol value for the character</returns>
            public static int CodeValueForChar(int CharAscii)
            {
                return (CharAscii >= 32) ? CharAscii - 32 : CharAscii + 64;
            }

            /// <summary>
            /// Return the appropriate START code depending on the codeset we want to be in
            /// </summary>
            /// <param name="cs">The codeset you want to start in</param>
            /// <returns>The code128 code to start a barcode in that codeset</returns>
            public static int StartCodeForCodeSet(CodeSet cs)
            {
                return cs == CodeSet.CodeA ? cSTARTA : cSTARTB;
            }

            /// <summary>
            /// Return the Code128 stop code
            /// </summary>
            /// <returns>the stop code</returns>
            public static int StopCode()
            {
                return cSTOP;
            }

            /// <summary>
            /// Indicates which code sets can represent a character -- CodeA, CodeB, or either
            /// </summary>
            public enum CodeSetAllowed
            {
                CodeA,
                CodeB,
                CodeAorB
            }

        }
    }
}
