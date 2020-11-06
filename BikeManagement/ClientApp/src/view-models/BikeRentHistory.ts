export interface BikeRentHistory {
  id: number;
  customerName: string;
  checkOutTime: Date;
  checkInTime: Date;
  timeSpent: number;
  bikeId: number;
}
