﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Entities;

namespace Logic.Filtering_and_Sorting
{
    public class GameTitleComparer : IComparer<Game>
    {
        public int Compare(Game x, Game y)
        {
            return x.Title.CompareTo(y.Title);
        }
    }
}
