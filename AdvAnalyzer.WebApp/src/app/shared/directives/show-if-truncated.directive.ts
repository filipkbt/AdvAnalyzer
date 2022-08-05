import { AfterViewInit, Directive, ElementRef, HostListener, OnInit } from "@angular/core";
import { MatTooltip } from "@angular/material/tooltip";

@Directive({
  selector: '[matTooltip][appShowIfTruncated]'
})
export class ShowIfTruncatedDirective implements AfterViewInit {
  constructor(
    private matTooltip: MatTooltip,
    private elementRef: ElementRef<HTMLElement>
  ) {
  }

  public ngAfterViewInit(): void {
    const element = this.elementRef.nativeElement;
    this.matTooltip.disabled = element.scrollWidth <= element.clientWidth;
  }
}