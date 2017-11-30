using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATYA
{
    public class KATYAMiscellaneous
    {
        public StatusObject Login()
        {
            StatusObject SO = new StatusObject();
            try
            {
                KATYAWebRequest LoginRequest = new KATYAWebRequest("http://localhost/claims/index.cfm?fusebox=MTRsec&fuseaction=act_login&");
                LoginRequest.AddRequestParameters("sleUserName", "MMSHAWN");
                LoginRequest.AddRequestParameters("slePassword", "AE27F329C3F17A5E7F701CB82231B297C48E9B1D00408F799DE0EB0F93536AFF51F0B71C87040AF8E903683BB81FB7B2CF18B3A742162D4E7C4D837167190F95");
                LoginRequest.AddRequestParameters("Nonce", "MTEvMzAvMjAxNyAwOTo0MDo0NTh4CF8EDA4C2B1850CD7E2020AB1BDA8995F82A68E2B99DB74F37CBECA1FEE7DF7C20B8DDEB6B1F03434045A3942F4B32BF7A1C2BD0E4BC2516DD19F06FCD38129");
                LoginRequest.AddRequestParameters("hpwd", "05D64E496CA79F5D135BB85C5D6016AB426A2A34F4BC712BE8ECD5CE97571ADE0D79A5FDBA58DD8B005C2C7C38B5333247F2352A181CC1681625EAD8398DE466");
                LoginRequest.AddRequestParameters("Login", "");
                Console.WriteLine(LoginRequest.GetURLEncodedString());
                LoginRequest.Post(false);
            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public StatusObject ClaimCreate()
        {
            StatusObject SO = new StatusObject();
            try
            {
                KATYAWebRequest ClaimCreateRequest = new KATYAWebRequest("http://localhost/claims/index.cfm?fusebox=MTRclaim&fuseaction=act_clmreg&clmgroup=MTR&srcdomainid=0&srcobjid=0&srclinkid=0&srctype=&caseid=0&extid=0&irepcardid=&CFID=537&CFTOKEN=6233b45edc7a5656-73EA2FAF-A9B3-DE35-A93FBD0BC9005A42&USID=792&RID=1658808&BR=4*");

                ClaimCreateRequest.AddRequestParameters("sleEPLPOLID","");
                ClaimCreateRequest.AddRequestParameters("slePOLID", "");
                ClaimCreateRequest.AddRequestParameters("sleCURINSCOID", "0");
                ClaimCreateRequest.AddRequestParameters("ddlbINSCOID", "4");
                ClaimCreateRequest.AddRequestParameters("ddlbInsurer", "4");
                ClaimCreateRequest.AddRequestParameters("ddlbCLAIMTYPE", " OD");
                ClaimCreateRequest.AddRequestParameters("flg_epl_integration", " 0");
                ClaimCreateRequest.AddRequestParameters("flg_epl_integration_pol_found", "   0");
                ClaimCreateRequest.AddRequestParameters("cbxSUBCLMTYPE", "   0");
                ClaimCreateRequest.AddRequestParameters("CLMFLAGMASK", " 4");
                ClaimCreateRequest.AddRequestParameters("CLMFLAG", " 0");
                ClaimCreateRequest.AddRequestParameters("INS_NEXT_CSTAT", "  1");
                ClaimCreateRequest.AddRequestParameters("sleACCDATE", "  30/11/2017");
                ClaimCreateRequest.AddRequestParameters("sleACCTIME", "  11");
                ClaimCreateRequest.AddRequestParameters("sleCLMnmsel", " 2");
                ClaimCreateRequest.AddRequestParameters("sleCLMnm", "KKKISAWEasdsadSOME");
                ClaimCreateRequest.AddRequestParameters("REGCMTINJUREDEXISTS", " 1");
                ClaimCreateRequest.AddRequestParameters("REGCMTINJURED", "1");
                ClaimCreateRequest.AddRequestParameters("sleCLMID1sel", "2");
                ClaimCreateRequest.AddRequestParameters("sleCLMID1", "");
                ClaimCreateRequest.AddRequestParameters("sleCLMID2sel", "4");
                ClaimCreateRequest.AddRequestParameters("sleCLMID2", "");
                ClaimCreateRequest.AddRequestParameters("sleREGNO", DateTime.Now.ToString());
                ClaimCreateRequest.AddRequestParameters("sleCHANO", "");
                ClaimCreateRequest.AddRequestParameters("ddlbREPCOID", " 1137");
                ClaimCreateRequest.AddRequestParameters("NOWORKSHOP", "  1");
                ClaimCreateRequest.AddRequestParameters("REPTRFCASEEXISTS", "8");
                ClaimCreateRequest.AddRequestParameters("sleINITIALEST_DD", "");
                ClaimCreateRequest.AddRequestParameters("sleINITIALEST_SLE", "");
                ClaimCreateRequest.AddRequestParameters("sleINITIALEST_SEL", "DD");
                ClaimCreateRequest.AddRequestParameters("SETTLETYPE", "  0");
                ClaimCreateRequest.AddRequestParameters("ddlbDAMTYPE", "");
                ClaimCreateRequest.AddRequestParameters("mleLossDesc", "");
                ClaimCreateRequest.AddRequestParameters("sibackend", "   1");
                ClaimCreateRequest.AddRequestParameters("slePOLNO", " KKKISAWESOME");
                ClaimCreateRequest.AddRequestParameters("siISCOVERNOTEOPTION", " 1");
                ClaimCreateRequest.AddRequestParameters("ddlbPOLCOVER", "1");
                ClaimCreateRequest.AddRequestParameters("ddlbNEWPOL" ,"0");
                ClaimCreateRequest.AddRequestParameters("LBLJS", "30781,30952");
                ClaimCreateRequest.AddRequestParameters("slePOLFROM", "");
                ClaimCreateRequest.AddRequestParameters("slePOLTO", "");
                ClaimCreateRequest.AddRequestParameters("mnSUMINSURED", "");
                ClaimCreateRequest.AddRequestParameters("mnSUMINSURED2", "");
                ClaimCreateRequest.AddRequestParameters("preexclist", "");
                ClaimCreateRequest.AddRequestParameters("preexcxml", "");
                ClaimCreateRequest.AddRequestParameters("intexclist", "");
                ClaimCreateRequest.AddRequestParameters("intexcxml", "");
                ClaimCreateRequest.AddRequestParameters("othexcxml", "");
                ClaimCreateRequest.AddRequestParameters("othexcremlist", "");
                ClaimCreateRequest.AddRequestParameters("savetot", "");
                ClaimCreateRequest.AddRequestParameters("DXS", " 10,000,000.00");
                ClaimCreateRequest.AddRequestParameters("DXSWAIVEDEXISTS", " 1");
                ClaimCreateRequest.AddRequestParameters("mn2F", "");
                ClaimCreateRequest.AddRequestParameters("sle2FREMARKS", "");
                ClaimCreateRequest.AddRequestParameters("sleInmsel", "   2");
                ClaimCreateRequest.AddRequestParameters("sleInm", "");
                ClaimCreateRequest.AddRequestParameters("sleIID1sel", "2");
                ClaimCreateRequest.AddRequestParameters("sleIID1", "");
                ClaimCreateRequest.AddRequestParameters("sleIID2sel", "4");
                ClaimCreateRequest.AddRequestParameters("sleIID2", "");
                ClaimCreateRequest.AddRequestParameters("sleTPREGNO", "");
                ClaimCreateRequest.AddRequestParameters("ddlbKFK", "");
                ClaimCreateRequest.AddRequestParameters("TPINSCOID_EXISTS", "1");
                ClaimCreateRequest.AddRequestParameters("PSCID", "4");
                ClaimCreateRequest.AddRequestParameters("ddlbMan", "10");
                ClaimCreateRequest.AddRequestParameters("ddlbModel", "5886");
                ClaimCreateRequest.AddRequestParameters("FORMGUID", Guid.NewGuid().ToString());
                StatusObject SO_Regular = ClaimCreateRequest.Post(true);
                if (SO_Regular.Status == StatusCode.FAILURE)
                {
                    Console.WriteLine(SO_Regular.ErrorStackTrace);
                }
            }
            catch(Exception e)
            {

            }
            return SO;
        }
    }
}
