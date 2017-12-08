using System.Collections.Generic;
using Infrastructure;
using Infrastructure.Order;
using Repositories.StoryRepository;

namespace Model.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }


        public Image GetImage(int idImage)
        {
            if (idImage == 0)
                return null;

            return this.imageRepository.GetById(idImage);
        }
    }
}
