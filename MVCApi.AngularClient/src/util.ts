export const isEmpty = (value: any) => {
  return (
    value == null || // NULL value
    value == undefined || // undefined
    value == 'undefined' || // undefined
    value.length == 0 || // Array is empty
    value == '00000000-0000-0000-0000-000000000000' || // Guid empty
    (value instanceof Date &&
      !isNaN(value.valueOf()) && // Validate DateTime value and check min-max value
      (value <= new Date(1753, 1, 1) || // SQL DateTime minimum value
        value >= new Date(9999, 12, 31, 23, 59, 59, 999))) // SQL DateTime maximum value
  );
};
