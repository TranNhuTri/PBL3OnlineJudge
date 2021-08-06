using System;
using System.Collections.Generic;

namespace PBL3.DTO
{
    public class SearchArticleInfor
    {
        public string articleName{get; set;}
        public int isPublic {get; set;}
        public string searchText{get; set;}
        public int authorID{get; set;}
    }
}