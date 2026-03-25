import { Component } from '@angular/core';

@Component({
  selector: 'app-about',
  imports: [],
  templateUrl: './about.html',
  styleUrl: './about.scss',
})
export class About {
  heroTitle: string = `About Site`;
  heroSubtitle: string = 'Judd Fashion by Judd Lasater';

  openLink(link: string) {
    window.open(link, '_blank');
  }
}
