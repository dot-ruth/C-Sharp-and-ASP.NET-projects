import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css']
})
export class ShowDepComponent implements OnInit {

  constructor(private service:SharedService) { }

  departmentList:any = [];
  ModalTitle:string = "";
  ActivateAddEditDepComp:boolean=false;
  dep:any;


  ngOnInit(): void {
    this.refreshdepList();
  }
  addClick(){
  this.dep={
    departmentId:0,
    departmentName:""
  }
  this.ModalTitle="Add Department";
  this.ActivateAddEditDepComp=true;
  console.log(this.ActivateAddEditDepComp)
  }
  closeClick(){
    this.ActivateAddEditDepComp=false;
    this.refreshdepList();
  }

  refreshdepList ()  {
    this.service.getDeptList().subscribe(
      (data ) => {
     this.departmentList = data;
    });
  }
}
