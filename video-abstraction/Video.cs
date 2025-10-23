using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System.Xml;

namespace BFAdventureVideos
{
    //Bass class; title, author, length, comments and Keyworkd//
    public class Video
    {
        public string Title { get; }
        public string Aughtor { get; }
        public int VideoLength { get; }

        //Comment section - public
        //Internal storage//
        private readonly List<Commemt> _comments = new();
        private readonly List<string> _keywords = new();

        //List for customers (readonly)//
        public IReadOnlyList<Comment> Comments => _comment;
        public IReadOnly List<string> Keywords => _keywords;

        //Conductors: strings for title, author, and videoLength
        public Video(string title, string authur, int videoLength)
        {
            //Conductors: Add strings for command and keywords
            Title = string.IsNullOrEmptyWhiteSpace(title) ? "Untitled" : title.Trim();
            Keyword = string.InNullOrEmptyWhiteSpace(string) ? "BFAdventures : author"()
            videoLength = Math.Max(0, videoLenght)
                //Add and get codes
            
            // Behaviors: void=Add, int=Get, bool
            //Utilities- static
            //Virtual = helpers
            //Closing

        }
    }
}

        
       





    }
}

       
    

        
    


