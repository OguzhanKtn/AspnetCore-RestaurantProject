using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _SocialMediaDal;

        public SocialMediaManager(ISocialMediaDal SocialMediaDal)
        {
            _SocialMediaDal = SocialMediaDal;
        }

        public void TAdd(SocialMedia entity)
        {
            _SocialMediaDal.Add(entity);
        }

        public void TDelete(SocialMedia entity)
        {
            _SocialMediaDal.Delete(entity);
        }

        public List<SocialMedia> TGetAll()
        {
            return _SocialMediaDal.GetAll();
        }

        public SocialMedia TGetById(int id)
        {
            return _SocialMediaDal.GetById(id);
        }

        public void TUpdate(SocialMedia entity)
        {
            _SocialMediaDal.Update(entity);
        }
    }
}
