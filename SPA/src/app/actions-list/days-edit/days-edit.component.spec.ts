/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DaysEditComponent } from './days-edit.component';

describe('DaysEditComponent', () => {
  let component: DaysEditComponent;
  let fixture: ComponentFixture<DaysEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DaysEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DaysEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
