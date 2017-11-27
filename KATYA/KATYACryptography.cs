using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;
namespace KATYA
{
    public partial class KATYACryptography
    {
        public string ASCIICharacters = "";
        private string RootPath { get; set; }
        public KATYACryptography()
        {
            try
            {

            }
            catch(Exception e)
            {

            }
        }
        public BigInteger CalculatePermutationCount(int WordLength)
        {
            return BigInteger.Pow(ASCIICharacters.Length, WordLength);
        }
        public BigInteger CalculatePermutationCount(char FirstCharacter, int WordLength)
        {
            return BigInteger.Pow(ASCIICharacters.Length, WordLength - 1);
        }
        public StatusObject GenerateRainbowTableCreateQuery()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public StatusObject GenerateRainbowTableInsertQueries(int WordLength)
        {
            StatusObject SO = new StatusObject();
            try
            {
                
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "CRYPTOGRAPHY_GENERATERAINBOWTABLEINSERTQUERIES");
            }
            return SO;
        }
        public StatusObject MatchMD5Hash()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {

            }
            return SO;
        }
    }
}
