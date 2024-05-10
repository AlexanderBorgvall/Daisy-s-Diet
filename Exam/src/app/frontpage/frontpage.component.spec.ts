import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FrontPageComponent } from './frontpage.component';

describe('FrontpageComponent', () => {
  let component: FrontPageComponent;
  let fixture: ComponentFixture<FrontPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FrontPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FrontPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
