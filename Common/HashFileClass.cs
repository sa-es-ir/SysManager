using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class HashFileClass
    {
       public string Name { get; set; }
       public string Hash { get; set; }
    }

   public static class HashFileListClass
   {
       private static readonly List<HashFileClass> _hashList=new List<HashFileClass>() ;

       public static List<HashFileClass> HashList
       {
           set { _hashList.AddRange(value);}
           get
           {
               if (_hashList != null)
                   return _hashList;
               else
                   return new List<HashFileClass>();
           }
       } 
   }
}
