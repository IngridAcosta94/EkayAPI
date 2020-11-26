using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekay.Api.Controllers
{
	public class FirmaController
	{

      /*
        Chilkat.Crypt2 crypt = new Chilkat.Crypt2();

        // Use a digital certificate and private key from a PFX file (.pfx or .p12).
        string signingCertSubject = "Acme Inc";
        string pfxFilename = "/Users/chilkat/testData/pfx/acme.pfx";
        string pfxPassword = "test123";

        Chilkat.CertStore certStore = new Chilkat.CertStore();
        bool success = certStore.LoadPfxFile(pfxFilename, pfxPassword);
        if (success != true) 
            {
                 Debug.WriteLine(certStore.LastErrorText);
                return;
            }

            Chilkat.Cert cert = null;
            cert = certStore.FindCertBySubjectCN(signingCertSubject);
            if (certStore.LastMethodSuccess == false) {
             Debug.WriteLine("Failed to find certificate by subject common name.");
            return;
}

            // Tell the crypt component to use this cert.
            success = crypt.SetSigningCert(cert);

            // We can sign any type of file, creating a .p7m as output:
            string inFile = "/Users/chilkat/testData/pdf/sample.pdf";
            string outputFile = "/Users/chilkat/testData/p7m/sample.pdf.p7m";
            success = crypt.CreateP7M(inFile, outputFile);
            if (success == false)
            {
            Debug.WriteLine(crypt.LastErrorText);
        
               return;
            }
    
            // Verify and restore the original file:
            success = crypt.SetVerifyCert(cert);

            inFile = outputFile;
            outputFile = "/Users/chilkat/testData/pdf/restored.pdf";

            success = crypt.VerifyP7M(inFile, outputFile);
            if (success == false)
            {
                Debug.WriteLine(crypt.LastErrorText);

                return;
            }

            Debug.WriteLine("Success!");


        */




	}
}
