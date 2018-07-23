using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;

namespace CertData
{
    public static class CertRepository
    {
        public static async Task SetCompleteionStatusOnLastXCertsAsync(int numberOfCerts, bool isComplete)
        {
            using (var context = new NcmaContext())
            {
                var certs = await context.membercerts.OrderByDescending(x => x.ID).Take(numberOfCerts).ToListAsync();
                certs.ForEach(x => x.Completed = isComplete);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SaveCompleteAsync(int certId)
        {
            using (var context = new NcmaContext())
            {
                membercert retCert = context.membercerts.FirstOrDefault(c => c.ID == certId);
                if (retCert != null)
                {
                    retCert.Completed = true;
                }
                await context.SaveChangesAsync();
            }
        }

        public static async Task<List<vwCertificate>> SearchCertificatesAsync(string searchTerm)
        {
            using (var context = new NcmaContext())
            {
                return await context.vwCertificates
                    .Where(c => c.FullName.Contains(searchTerm)
                        || c.Dojo.Contains(searchTerm)
                        || c.InstructorsName.Contains(searchTerm)
                        || c.RankText.Contains(searchTerm)).OrderByDescending(c => c.ID)
                    .ToListAsync();
            }
        }

        public static async Task SaveIncompleteAsync(int certId)
        {
            using (var context = new NcmaContext())
            {
                membercert retCert = context.membercerts.FirstOrDefault(c => c.ID == certId);
                if (retCert != null)
                {
                    retCert.Completed = false;
                }
                await context.SaveChangesAsync();
            }
        }

        public static async Task<List<vwCertificate>> GetNewCertificatesAsync()
        {
            using (var context = new NcmaContext())
            {
                return await context.vwCertificates
                    .Where(c => !c.Completed.Value || !c.Completed.HasValue)
                    .ToListAsync();
            }
        }

        public static async Task<List<vwCertificate>> GetAllCertsAsync()
        {
            using (var context = new NcmaContext())
            {
                var certs = await context.vwCertificates
                    .OrderByDescending(c => c.ID)
                    .ToListAsync();

                return certs;
            }
        }

        public static async Task<List<vwCertificate>> SearchCertificatesByIdRangeAsync(int startId, int stopId)
        {
            using (var context = new NcmaContext())
            {
                return await context.vwCertificates
                    .Where(c => c.ID >= startId && c.ID <= stopId)
                    .OrderByDescending(c => c.ID)
                    .ToListAsync();
            }
        }
    }
}
