import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';

@Component({
  selector: 'app-admin-courses',
  templateUrl: './admin-courses.component.html',
  styleUrls: ['./admin-courses.component.css']
})
export class AdminCoursesComponent implements OnInit {

  baseUrl: string;
  client: HttpClient;
  courses: Course[];
  courseForm: FormGroup;
  errMsg: string;
  isLoaded: boolean;

  constructor(
    http: HttpClient,
    @Inject('BASE_URL') baseUrl,
    private fb: FormBuilder
  ) {
    this.client = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.getCourses();
    this.courseForm = this.fb.group({
      courseList: this.fb.array([])
    });
  }

  get coursesForm() {
    return this.courseForm.get('courseList') as FormArray
  }

  updateCourse(f: FormGroup) {
    //var data = JSON.stringify(f.get('courseList').value);
    var data = JSON.stringify((f.getRawValue())['courseList']);

    console.log(data);
    var headers = new HttpHeaders().set("Content-Type", "application/json");
    return this.client.post<Course[]>(this.baseUrl + "admin/UpdateCourse",
      data , { headers })
      .subscribe(res => {
      }, err => {
        this.errMsg = err;
        console.error(err);
      });
  }


  addCourse() {
    const course = this.fb.group({
      courseId: ['', Validators.required, Validators.minLength(6), Validators.maxLength(6)],
      name: ['', Validators.required, Validators.maxLength(30)],
      fee: ['', Validators.required]
    })
    this.coursesForm.push(course);
  }

  deleteCourse(i) {
    var toBeDeleted = (this.coursesForm.getRawValue())[i];
    console.log(toBeDeleted);
    var data = JSON.stringify(toBeDeleted);
    var headers = new HttpHeaders().set("Content-Type", "application/json");
    this.client.post<Course>(this.baseUrl + "admin/RemoveCourse",
      data, { headers })
      .subscribe(res => {
      }, err => {
        this.errMsg = err;
        console.error(err);
      });
    this.coursesForm.removeAt(i);
  }

  getCourses() {
    this.isLoaded = false;
    this.client.get<Course[]>(this.baseUrl + ("course/GetCourses"))
      .subscribe(
        res => {
          this.courses = res;
          this.courses.forEach(
            (c) => this.coursesForm.push(this.fb.group({
              courseId: [{ value : c.courseId, disabled: true }],
              name: c.name,
              fee: c.fee
            }))
          )
          this.isLoaded = true;
          console.log(res);
        },
        err => console.error(err)
      )
  }
}

export interface Course {
  courseId: string,
  name: string,
  fee: number,
}
