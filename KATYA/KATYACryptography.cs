using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace KATYA
{
    public class KATYACryptography
    {
        public string ASCIICharacters = "";
        public KATYACryptography()
        {

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
        public StatusObject GenerateRainbowTableInsertQueries()
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
