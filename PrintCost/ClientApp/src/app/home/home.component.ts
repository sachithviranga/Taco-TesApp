import { HttpClient, HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, Inject, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  baseUrl: string;
  fileCost: any = undefined;
  showLoader = false;
  isSubmitted = false;

  myForm = new FormGroup({
    isDoubleSide: new FormControl(false),
    file: new FormControl('', [Validators.required]),
    fileSource: new FormControl('', [Validators.required])
  });


  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  get f() { return this.myForm.controls; }

  onFileChange(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.myForm.patchValue({ fileSource: file });
    }
  }

  submit() {
    this.isSubmitted = true;
    this.fileCost = undefined;
    if (this.myForm.valid) {
      this.showLoader = true;
      const formData = new FormData();
      formData.append('file', this.myForm.get('fileSource').value);
      formData.append('isDoubleSide', this.myForm.get('isDoubleSide').value);
      const params = this.myForm.getRawValue();
      const url = this.baseUrl + 'api/costCalculate';
      this.http.post(url, formData)
        .subscribe(res => {
          this.showLoader = false;
          this.isSubmitted = false;
          if (!res['isError']) {  this.fileCost = res['returnObject']; }
          else { alert(res['message']['description']); }
        });
    }
  }

  reset() {
    this.myForm.reset();
    this.myForm.get('isDoubleSide').patchValue(false);
    this.fileCost = undefined;
    this.showLoader = false;
    this.isSubmitted = false;
  }
}
