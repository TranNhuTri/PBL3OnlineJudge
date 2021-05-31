using System;
using System.Collections.Generic;

namespace PBL3.DTO
{
    public class SearchProblemInfor
    {
        public string problemName{get; set;}
        public bool hideSolvedProblem{get; set;}
        public int? minDifficult{get; set;}
        public int? maxDifficult{get; set;}
        public int isPublic {get; set;}
        public string searchText{get; set;}
        public int authorID{get; set;}
    }
}