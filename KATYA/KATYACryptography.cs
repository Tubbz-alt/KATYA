using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;
using System.Security.Cryptography;
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
        public StatusObject MatchMD5Hash(string MD5HashString, char FirstCharacter)
        {
            StatusObject SO = new StatusObject();
            try
            {
                string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789~!@#$%^&*()_+-={}[]:\" |;'\\<>?,./";
                
            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public string GetMD5Hash(string Input)
        {
            string HashedString = "";
            try
            {
                MD5 Hasher = MD5.Create();
                byte[] InputBytes = Encoding.ASCII.GetBytes(Input);
                byte[] HashedBytes = Hasher.ComputeHash(InputBytes);
                HashedString = String.Join("", HashedBytes.Select(x => x.ToString("x2").ToUpper()));
                Console.WriteLine(HashedString);
            }
            catch(Exception e)
            {
                HashedString = null;
            }
            return HashedString;
        }
        public string GetSHA1Hash(string Input)
        {
            string HashedString = "";
            try
            {
                SHA1 Hasher = SHA1.Create();
                byte[] InputBytes = Encoding.ASCII.GetBytes(Input);
                byte[] HashedBytes = Hasher.ComputeHash(InputBytes);
                HashedString = String.Join("", HashedBytes.Select(x => x.ToString("x2").ToUpper()));
                Console.WriteLine(HashedString);
            }
            catch (Exception e)
            {
                HashedString = null;
            }
            return HashedString;
        }
        public string GetSHA256Hash(string Input)
        {
            string HashedString = "";
            try
            {
                SHA256 Hasher = SHA256.Create();
                byte[] InputBytes = Encoding.ASCII.GetBytes(Input);
                byte[] HashedBytes = Hasher.ComputeHash(InputBytes);
                HashedString = String.Join("", HashedBytes.Select(x => x.ToString("x2").ToUpper()));
                Console.WriteLine(HashedString);
            }
            catch (Exception e)
            {
                HashedString = null;
            }
            return HashedString;
        }
        public string GetSHA512Hash(string Input)
        {
            string HashedString = "";
            try
            {
                SHA512 Hasher = SHA512.Create();
                byte[] InputBytes = Encoding.ASCII.GetBytes(Input);
                byte[] HashedBytes = Hasher.ComputeHash(InputBytes);
                HashedString = String.Join("", HashedBytes.Select(x => x.ToString("x2").ToUpper()));
                Console.WriteLine(HashedString);
            }
            catch (Exception e)
            {
                HashedString = null;
            }
            return HashedString;
        }
    }
}
