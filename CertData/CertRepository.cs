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

        public static async Task SaveCompleteAsync(int certId, string batchId = null)
        {
            using (var context = new NcmaContext())
            {
                membercert retCert = context.membercerts.FirstOrDefault(c => c.ID == certId);
                if (retCert != null)
                {
                    retCert.Completed = true;

                    if (batchId != null &&  retCert.BatchID == null)
                        retCert.BatchID = batchId;
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
                        || c.BatchID.Contains(searchTerm)
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

        public static async Task SaveBatchId(string batchId, int certId)
        {
            using (var context = new NcmaContext())
            {
                var cert = await context.membercerts.FindAsync(certId);
                cert.BatchID = batchId;
                await context.SaveChangesAsync();
            }
        }

        public static async Task<List<vwCertificate>> GetCertsByBatchId(string batchId)
        {
            using (var context = new NcmaContext())
            {
                return await context.vwCertificates
                    .Where(c => c.BatchID == batchId)
                    .ToListAsync();
            }
        }

        public static async Task SetCertsCompletionStatusByBatchId(string batchId, bool isComplete)
        {
            using (var context = new NcmaContext())
            {
                var certs = await context.membercerts.Where(c => c.BatchID == batchId).ToListAsync();
                certs.ForEach(c => c.Completed = isComplete);
                await context.SaveChangesAsync();
            }
        }

    }
}
