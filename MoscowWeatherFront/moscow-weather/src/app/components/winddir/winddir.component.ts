import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-winddir',
  templateUrl: './winddir.component.html',
  styleUrls: ['./winddir.component.scss']
})
export class WinddirComponent implements OnInit {
  ngOnInit(): void {
    if (this.direction) console.log(this.direction)
  }
  @Input() direction: string
}
