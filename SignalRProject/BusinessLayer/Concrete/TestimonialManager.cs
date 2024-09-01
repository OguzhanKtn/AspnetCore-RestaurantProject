using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _TestimonialDal;

        public TestimonialManager(ITestimonialDal TestimonialDal)
        {
            _TestimonialDal = TestimonialDal;
        }

        public void TAdd(Testimonial entity)
        {
            _TestimonialDal.Add(entity);
        }

        public void TDelete(Testimonial entity)
        {
            _TestimonialDal.Delete(entity);
        }

        public List<Testimonial> TGetAll()
        {
            return _TestimonialDal.GetAll();
        }

        public Testimonial TGetById(int id)
        {
            return _TestimonialDal.GetById(id);
        }

        public void TUpdate(Testimonial entity)
        {
            _TestimonialDal.Update(entity);
        }
    }
}
