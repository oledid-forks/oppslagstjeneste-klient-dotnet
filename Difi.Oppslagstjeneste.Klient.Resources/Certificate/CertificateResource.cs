﻿using System;
using System.Security.Cryptography.X509Certificates;
using Digipost.Api.Client.Shared.Resources.Resource;

namespace Difi.Oppslagstjeneste.Klient.Resources.Certificate
{
    internal class CertificateResource
    {
        private static readonly ResourceUtility ResourceUtility = new ResourceUtility(
            typeof(CertificateResource).Assembly
            , "Difi.Oppslagstjeneste.Klient.Resources.Certificate.Data");

        internal static X509Certificate2 GetDifiTestCertificate()
        {
            var certificatePath = Environment.GetEnvironmentVariable("SMOKE_TEST_CERTIFICATE_PATH") ??
                                  throw new Exception("Env variable SMOKE_TEST_CERTIFICATE_PATH is not set. Certificate can therefore not be read.");

            var certificatePassword = Environment.GetEnvironmentVariable("SMOKE_TEST_CERTIFICATE_PASSWORD") ??
                                      throw new Exception("Env variable SMOKE_TEST_CERTIFICATE_PASSWORD is not set. Certificate can therefore not be read.");
            
            return new X509Certificate2(certificatePath, certificatePassword );
        }
        
        internal static X509Certificate2 GetEternalTestCertificateWithoutPrivateKey()
        {
            var bytes = ResourceUtility.ReadAllBytes( "difi-enhetstester.cer");
            return new X509Certificate2(bytes, "", X509KeyStorageFlags.Exportable);
        }

        internal static X509Certificate2 GetEternalTestCertificateWithPrivateKey()
        {
            var bytes = ResourceUtility.ReadAllBytes( "difi-enhetstester.p12");
            return new X509Certificate2(bytes, "changeit");
        }

        internal static X509Certificate2 GetTestMottakerCertificateFromOppslagstjenesten()
        {
            var bytes = ResourceUtility.ReadAllBytes( "testmottakersertifikatFraOppslagstjenesten.pem");
            return new X509Certificate2(bytes);
        }

        internal static X509Certificate2 GetProductionMottakerCertificateFromOppslagstjenesten()
        {
            var bytes = ResourceUtility.ReadAllBytes( "produksjonsmottakersertifikatFraOppslagstjenesten.pem");
            return new X509Certificate2(bytes);
        }
    }
}
