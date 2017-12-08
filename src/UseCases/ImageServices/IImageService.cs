using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using Infrastructure.Order;


namespace Model.Services
{
    public interface IImageService
    {
        Image GetImage(int idImage);

    }
}
