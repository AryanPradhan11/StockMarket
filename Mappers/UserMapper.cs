using Microsoft.Extensions.Configuration.UserSecrets;

public static class UserMapper {
    public static UserDto userFilter(this User userModel) {
        return new UserDto {
            userId = userModel.userID,
            userName = userModel.userName,
            userType = userModel.userType
        };
    }

    public static User createCustomer(this CreateCustomerDto customerDto) {
        return new User {
            userName = customerDto.userName,
            userType = customerDto.userType
        };
    }
}

