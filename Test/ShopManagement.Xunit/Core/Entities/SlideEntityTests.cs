using ShopManagement.Core.Entities.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Xunit.Core.Entities
{
    public class SlideEntityTests
    {
        [Fact]
        public void Constructor_SetsProperties()
        {
            // Arrange
            var picture = "test.jpg";
            var alt = "Slide image";
            var title = "Image title";
            var heading = "Slide heading";
            var slideTitle = "Slide title";
            var text = "Slide text";
            var btnText = "Button text";

            // Act
            var slide = new SlideEntity(picture, alt, title, heading, slideTitle, text, btnText);

            // Assert
            Assert.Equal(picture, slide.Picture);
            Assert.Equal(alt, slide.PictureAlt);
            Assert.Equal(title, slide.PictureTitle);
            Assert.Equal(heading, slide.Heading);
            Assert.Equal(slideTitle, slide.Title);
            Assert.Equal(text, slide.Text);
            Assert.Equal(btnText, slide.BtnText);
            Assert.False(slide.IsRemoved);
        }

        [Fact]
        public void Edit_UpdatesProperties()
        {
            // Arrange
            var slide = new SlideEntity("1.jpg", "Img 1", "Title 1", "Heading 1",
                "Title 1", "Text 1", "Btn 1");
            var newPicture = "2.jpg";
            var newAlt = "Img 2";

            // Act
            slide.Edit(newPicture, newAlt, "Title 1", "Heading 1",
                "Title 1", "Text 1", "Btn 1");

            // Assert
            Assert.Equal(newPicture, slide.Picture);
            Assert.Equal(newAlt, slide.PictureAlt);
            Assert.Equal("Title 1", slide.PictureTitle);
            Assert.Equal("Heading 1", slide.Heading);
            Assert.Equal("Title 1", slide.Title);
            Assert.Equal("Text 1", slide.Text);
            Assert.Equal("Btn 1", slide.BtnText);
        }

        [Fact]
        public void Remove_SetsIsRemovedToTrue()
        {
            // Arrange
            var slide = new SlideEntity("test.jpg", "Test", "Test", "Test",
                "Test", "Test", "Test");

            // Act
            slide.Remove();

            // Assert
            Assert.True(slide.IsRemoved);
        }

        [Fact]
        public void Restore_SetsIsRemovedToFalse()
        {
            // Arrange 
            var slide = new SlideEntity("test.jpg", "Test", "Test", "Test",
                "Test", "Test", "Test")
            {  };
            slide.Remove();

            // Act
            slide.Restore();

            // Assert
            Assert.False(slide.IsRemoved);
        }
    }
}
