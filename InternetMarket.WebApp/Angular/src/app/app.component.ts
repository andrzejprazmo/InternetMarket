import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Angular';

  constructor(private http: HttpClient) {

    const url = '/api/customer/get-customer/HANAR';
    http.get(url).subscribe(r => {
      console.log(r);
    });
  }
}
