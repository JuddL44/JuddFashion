import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Navbar } from './components/navbar/navbar';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Navbar],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App {
  imageURL: string =
    'https://media.discordapp.net/attachments/1442661804982538350/1475537518467354634/preview.png?ex=699dd8e6&is=699c8766&hm=4ab24a47e16fa2a9f42aa66e7853f58a616589c2f4801a7d90a42e3f393130ea&=&format=webp&quality=lossless';
  protected readonly title = signal('JuddFashion.CLIENT');
}
