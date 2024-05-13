import * as FilePond from "filepond";
import FilePondPluginFileValidateType from "filepond-plugin-file-validate-type";

const inputElement = document.querySelector("#js-file-pond");
const formElement = document.querySelector("#js-form");

FilePond.registerPlugin(FilePondPluginFileValidateType);

const pond = FilePond.create(inputElement, {
  allowDrop: true,
  allowMultiple: true,
  allowReorder: true,
  storeAsFile: true,
  acceptedFileTypes: ["image/jpeg", "image/png"],
});

const filepondLabel = document.querySelector(".filepond--drop-label");

pond.on("updatefiles", (files) => {
  if (files.length === 0) filepondLabel.style.height = "100%";
  if (files.length > 0) filepondLabel.style.height = "auto";
  if (files.length <= 2) filepondLabel.style.minHeight = "4.75em";
  if (files.length > 2) filepondLabel.style.minHeight = "auto";
});

formElement.onsubmit = async (e) => {
  e.preventDefault();
  const data = new FormData(formElement);

  const response = await fetch(
    "https://localhost:55523/FormData/ProcessFormData",
    {
      method: "POST",
      body: data,
    }
  );
};
