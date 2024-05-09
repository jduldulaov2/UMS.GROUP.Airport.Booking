import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultPortalComponent } from './default-portal.component';

describe('DefaultPortalComponent', () => {
  let component: DefaultPortalComponent;
  let fixture: ComponentFixture<DefaultPortalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DefaultPortalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DefaultPortalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
