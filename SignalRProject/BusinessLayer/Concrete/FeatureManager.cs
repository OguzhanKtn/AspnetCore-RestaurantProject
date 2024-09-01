using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _FeatureDal;

        public FeatureManager(IFeatureDal FeatureDal)
        {
            _FeatureDal = FeatureDal;
        }

        public void TAdd(Feature entity)
        {
            _FeatureDal.Add(entity);
        }

        public void TDelete(Feature entity)
        {
            _FeatureDal.Delete(entity);
        }

        public List<Feature> TGetAll()
        {
            return _FeatureDal.GetAll();
        }

        public Feature TGetById(int id)
        {
            return _FeatureDal.GetById(id);
        }

        public void TUpdate(Feature entity)
        {
            _FeatureDal.Update(entity);
        }
    }
}
