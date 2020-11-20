import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'life-ui';

  constructor(private http: HttpClient) {
    http.get('https://localhost:44306/api/word').subscribe((x) => {
        console.log(x);
    });
  }
}
