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

        //Comment section//
        //Internal storage//
        private readonly List<Commemt> _comments = new();
        private readonly List<string> _keywords = new();
    
        //List for customers (readonly)//
        public IReadOnlyList<Comment> Comments => _comment;
        public IReadOnly List<string> Keywords => _keyworks;

        //Strings for title, author, and videoLength
        //Add command
        //Add keyword
    { 
{ 

        
       





    }
}

       
    

        
    


