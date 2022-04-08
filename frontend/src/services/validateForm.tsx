export const validateString = (str: string) => {
  const pattern = /^[^`~#$%^&={}\[\]|\\<>๐฿]*$/g;
  const check = pattern.exec(str);
  if (check !== null) {
    return "";
  }
  return `Vui lòng không nhập các ký tự đặc biệt`;
};

export const validatePhoneNumber = (phone: string) => {
  const pattern = /^[0-9]{10}$/g;
  const check = pattern.exec(phone);
  if (check !== null) {
    return "";
  }
  return `Quý khách vui lòng nhập số điện thoại gồm 10 chữ số.`;
};
