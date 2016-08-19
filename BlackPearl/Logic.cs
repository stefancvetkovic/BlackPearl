﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPearl
{
    public class Logic
    {
        public void FindAndReplace(Microsoft.Office.Interop.Word.Application doc, object findText, object replaceWithText)
        {
           //options
            object matchCase = false;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            //object matchKashida = false;
            //object matchDiacritics = false;
            //object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            //execute find and replace
            doc.Selection.Find.Execute(
                ref findText, 
                ref matchCase, 
                ref matchWholeWord,
                ref matchWildCards, 
                ref matchSoundsLike, 
                ref matchAllWordForms, 
                ref forward, 
                ref wrap, 
                ref format, 
                ref replaceWithText, 
                ref replace,
                //ref matchKashida, 
                //ref matchDiacritics, 
                //ref matchAlefHamza, 
                ref matchControl);
        }
    }
}
