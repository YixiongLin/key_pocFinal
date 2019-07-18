function ShowImagePreview(ImageUploader, ImagePreview) {
    if (ImageUploader.files && ImageUploader.files[0]) // Check if we have uploaded Image or Not
    {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(ImagePreview).attr('src', e.target.result);
        }
        reader.readAsDataURL(ImageUploader.files[0]);
    }
}