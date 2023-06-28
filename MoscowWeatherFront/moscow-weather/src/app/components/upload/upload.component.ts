import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss']
})
export class UploadComponent implements OnInit {
  fileForm: FormGroup;
  error: string;
  loading: boolean;

  constructor(private http: HttpClient, private builder: FormBuilder) {}

  ngOnInit() {
    this.fileForm = this.builder.group({
      file: ['']
    });
  }

  onFileSelect(event: any) {
    if (event.target.files.length > 0) {
      this.fileForm.get('file')?.setValue(event.target.files);
      console.log('You select files')
    }
    else {
      console.log('You dont select file')
    }
  }

  sendData() {
    if (this.fileForm.valid) {
      this.loading = true
      let data = new FormData()
      let files = this.fileForm.get('file')?.value
      for (let i = 0; i < files.length; i++) {
        data.append('file', files[i])
      }
      this.http.post('https://localhost:5126/api/v1/weatherforecast', data)
        .subscribe(
          (res) => { console.log(res); this.error = '' },
          (err) => { console.log(err); this.error = "Something went wrong"; this.loading = false },
          () => { this.loading = false }
        )
    }
    else
    {
      this.error = "File required!"
    }
  }
}
