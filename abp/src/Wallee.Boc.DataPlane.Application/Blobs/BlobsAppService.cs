using Volo.Abp.BlobStoring;

namespace Wallee.Boc.DataPlane.Blobs
{
    public class BlobsAppService : DataPlaneAppService, IBlobsAppService
    {
        private readonly IBlobContainer<DataPlaneFileContainer> _blobContainer;

        public BlobsAppService(IBlobContainer<DataPlaneFileContainer> blobContainer)
        {
            _blobContainer = blobContainer;
        }
    }
}
