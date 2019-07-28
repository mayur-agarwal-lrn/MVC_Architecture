using System;
using System.Web.Mvc;
using UniversityApp.Models;

namespace MVCArchitecture.Web.BAL
{
    public class StudentCustomBinder : DefaultModelBinder
    {
        //public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        //{
        //    if (bindingContext.ModelType == typeof(Student))
        //    {
        //        var request = controllerContext.HttpContext.Request;

        //        var day = Convert.ToInt32(request.Form.Get("AdmissionDate.Day"));
        //        var month = Convert.ToInt32(request.Form.Get("AdmissionDate.Month"));
        //        var year = Convert.ToInt32(request.Form.Get("AdmissionDate.Year"));

        //        var student = (Student)base.BindModel(controllerContext, bindingContext);
        //        student.AdmissionDate = new DateTime(year, month, day);
        //        return student;
        //    }
        //    return base.BindModel(controllerContext, bindingContext);
        //}

        protected override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
        {
            if (propertyDescriptor.ComponentType == typeof(Student)
                && propertyDescriptor.Name == "AdmissionDate")
            {
                var request = controllerContext.HttpContext.Request;

                var day = Convert.ToInt32(request.Form.Get("AdmissionDate.Day"));
                var month = Convert.ToInt32(request.Form.Get("AdmissionDate.Month"));
                var year = Convert.ToInt32(request.Form.Get("AdmissionDate.Year"));

                if (DateTime.TryParse($"{year}-{month}-{day}", out var admissionDate))
                    return admissionDate;
            }
            return base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
        }
    }
}