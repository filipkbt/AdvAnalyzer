import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdvertisementListContainerComponent } from './advertisement-list-container.component';

describe('AdvertisementListContainerComponent', () => {
  let component: AdvertisementListContainerComponent;
  let fixture: ComponentFixture<AdvertisementListContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdvertisementListContainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdvertisementListContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
