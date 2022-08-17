import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css']
})
export class ShowDepComponent implements OnInit {

  constructor(private service:SharedService) { }

  departmentList:any = null;

  ngOnInit(): void {
    console.log(this.departmentList);
    this.refreshdepList();
    
  }

  refreshdepList(){
    this.service.getDeptList().subscribe(data => {
     this.departmentList = data;
     console.log(this.departmentList);
    });
    //console.log(this.departmentList);
  }
}
